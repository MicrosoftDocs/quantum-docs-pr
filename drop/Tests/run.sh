#!/bin/bash
set -x
set -e

: ${BuildFolder:="tests.generated"}

# On macOS and Linux, the build agent doesn't add the ~/.local/bin to PATH
# automatically, such that pip user installs fail on those platforms. On
# Windows, though, this path _shouldn't_ be on PATH.
unameOut="$(uname -s)"
case "${unameOut}" in
    Linux*)
      machine=Linux;
      export PATH=~/.local/bin:$PATH
      ;;
    Darwin*)
      machine=Mac;
      export PATH=~/.local/bin:$PATH;
      brew install coreutils;
      ;;
    CYGWIN*)
      machine=Cygwin
      ;;
    MINGW*)
      machine=MinGw
      ;;
    *)
      machine="UNKNOWN:${unameOut}"
      ;;
esac
echo "Detected build agent machine: ${machine}"

# Ensure that we run everything from the directory containing this script.
cd $(dirname $(realpath $0))

#
# This script executes Solid sanity tests. It depends on
# setup.sh be executed first.
#
if [ ! -d $BuildFolder ]; then
  # Note that we don't source the script directly in case +x isn't set. We can't
  # just run chmod +x either, since that may not be supported on our current
  # host platform.
  bash ./setup.sh
fi

## C# sanity tests
pushd $BuildFolder
dotnet test tests-ootb --logger trx -v n
dotnet test tests-all --logger trx -v n
popd


## Jupyter sanity tests
if [ "$ENABLE_PYTHON" != "false" ]; then
  test_notebook() {
    pushd $1
    rm -Rdf obj
    jupyter nbconvert Notebook.ipynb --execute --stdout --to markdown --ExecutePreprocessor.timeout=120
    popd
  }
  test_notebook Jupyter/Basic
  test_notebook Jupyter/Kata


  ## Python sanity tests
  pushd Python
  rm -Rdf obj
  python -m pytest --doctest-modules --junitxml=junit/test-results.xml
  popd
fi
