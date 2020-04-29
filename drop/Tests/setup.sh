#!/bin/bash 
set -x
set -e

root=$PWD

: ${BuildFolder:="tests.generated"}
: ${NUGET_OUTDIR:="../drops/nugets"}
: ${PYTHON_OUTDIR:="../drops/wheels"}

# On macOS we need to explicitly install coreutils, to get `realpath`.
if [ "$(uname)" == "Darwin" ]; then
  brew install coreutils
fi

# Make sure DOTNET_ROOT is set, otherwise .NET global tools fail on first dotnet run.
# See https://github.com/dotnet/cli/issues/9114 for more details about DOTNET_ROOT.
if [ -z "$DOTNET_ROOT" ]; then export DOTNET_ROOT=$(dirname "$(realpath "$(which dotnet)")"); fi;


# Creates a dotnet project
createProject() {
    pushd $root/$BuildFolder

        projectType=$1
        projectName=$2
        mkdir "$projectName"
        pushd "$projectName"
            dotnet new $projectType -lang Q#
            cp -r "$root/Templates/$projectType/$projectName/"* .
            if [ "$projectName" == "Samples" ]; then 
                dotnet add package Microsoft.Quantum.Chemistry -v $version
                dotnet add package Microsoft.Quantum.Numerics -v $version
                dotnet add package Microsoft.Quantum.Research -v $version
            fi
        popd

        dotnet sln Tests.sln add "$projectName"/"$projectName".csproj
    popd
}

if [ -d $BuildFolder ]; then 
  rm -Rdf $BuildFolder;
fi

# For troubleshooting
dotnet --info

# Remove any existing templates
dotnet new --uninstall Microsoft.Quantum.ProjectTemplates

# Add new templates:
folder=${NUGET_OUTDIR//\\/\/}
version=$NUGET_VERSION
if [ "$version" == "" ]; then
  version=`ls $folder/Microsoft.Quantum.ProjectTemplates.* | tail -1  | sed "s/.*ProjectTemplates\.\(.*\).nupkg/\1/g"`
fi
templates="$folder/Microsoft.Quantum.ProjectTemplates.$version.nupkg"
dotnet new --install $templates

# Create solution
mkdir -p $BuildFolder
pushd $BuildFolder
dotnet new sln -n Tests
popd

# Create individual projects:
for t in `ls $root/Templates`
do
    pushd $root/Templates/$t
    for n in *
    do
        createProject $t "$n"
    done
    popd
done

# tests-all is the target Test project with the actual Tests, so it needs 
# reference to all other projects.
pushd $BuildFolder/tests-all
    dotnet sln ../Tests.sln list | grep .csproj | grep -v tests-all |
    while read -r p
    do
        clean=${p//[$'\t\r\n']}
        echo adding $clean
        dotnet add reference ../"$clean"
    done
popd


# Restore packages when we still have a good nuget.config:
dotnet restore $BuildFolder/Tests.sln


# Install Python module:
if [ "$ENABLE_PYTHON" != "false" ]; then
    folder=${PYTHON_OUTDIR//\\/\/}
    case $version in
        *-pull) py_version=`echo $version | sed  "s/\(.*\)-.*/\1a1/g"`;;
        *-alpha) py_version=`echo $version | sed  "s/\(.*\)-.*/\1a1/g"`;;
        *-beta) py_version=`echo $version | sed  "s/\(.*\)-.*/\1b1/g"`;;   
        *) py_version=$version;;
    esac
    pip install --user pytest jupyter qsharp==$py_version --find-links $folder


    # Install IQSharp inside the build folder:
    dotnet tool uninstall -g Microsoft.Quantum.IQSharp || true
    dotnet tool install --version $version Microsoft.Quantum.IQSharp --add-source .. --tool-path $BuildFolder
    pushd $BuildFolder
        iqs=`ls dotnet-iqsharp*`
        ./$iqs install --user --path-to-tool "$root/$BuildFolder/$iqs"
    popd
fi
