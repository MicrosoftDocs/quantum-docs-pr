#!/bin/bash
set -x
set -e

# Ensure that we run everything from the directory containing this script.
cd $(dirname $(realpath $0))

: ${WorkspaceFolder:="/workspace"}
: ${TestUser:="jovyan"}

# Running from a container takes one additional step: we need to give the test
# user (jovyan) access to the build folder so that they can write generated
# tests and results.

chown -R $TestUser:$TestUser $WorkspaceFolder

# We can now drop back down to the test user and finish running tests.
su -c "bash run.sh" $TestUser
