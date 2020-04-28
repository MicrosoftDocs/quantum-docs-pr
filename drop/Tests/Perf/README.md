# Performance Monitoring Pipeline

This pipeline is used to monitor the runtime performance of Q# programs.

It runs 4 tests:
- H2Simulation
- KDTest
- ModularAddProductLETest
- NoOp

On each run, it measures the TotalExecution time and how much time is spent on each Q# Gate on 
3 different Simulators:
- DefaultSimulator (i.e. `QuantumSimulator()`)
- NoBorrowingSimulator (i.e. `QuantumSimulator(disableBorrowing: true)`)
- QCTracerSimulator (only on those gates that have been enabled).

After running it reports the results to the console and automatically appends the results to the
[perf-results.txt](qperf/perf-results.txt) file.

It also accepts as a first argument the [key to an Azure CosmosDB](https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/e1d367ee-7905-4dbd-a215-9f8e4b435c7c/resourcegroups/solid/providers/Microsoft.DocumentDB/databaseAccounts/solid-perf/keys).
When provided, it will also check for trends and will automatically fail if any of the executions
shows a drop of more than 5% in the the average `TotalExecution` time of the last 15 successful runs; 
it only considers runs from the same machine, though.
If all the results are succesful, it will automatically upload them to the same `CosmosDB`.

To upload results even when a degradation is found qperf accepts a second `boolean` parameter
which will force the upload, e.g.:
` Tests/Perf/qperf $ dotnet run -- [THE_COSMOSDB_TOKEN] true `

The pipeline is schedule to run on `master` by the 
[Solid Performance Tracking](https://quarcsw.visualstudio.com/Solid/_apps/hub/ms.vss-ciworkflow.build-ci-hub?_a=edit-build-definition&id=38) build,
which is scheduled to automatically run daily at 3am and 3pm (Windows only)
This build is also triggered on every commit into `master` and typically is also setup as
a gate for PullRequests (Windows Only). Finally, the pipeline is also executed as part of the 
Release's sanity tests validation (for both signed and unsigned) on all platforms.


The uploaded results can be analyzed via [PowerBi](https://powerbi.microsoft.com/en-us/get-started/), 
using the [Solid Performance.pbix](qperf/Solid Performance.pbix) PowerBI file, 
or via the [online version](https://msit.powerbi.com/groups/5b5cea9c-0616-4b73-bc9c-b42f512f3cd1/reports/15f2ce9c-ce74-41a1-bab2-74c0a573c409/ReportSection)
There is also a [LocalRunReport.pbix](qperf/LocalRunReport.pbix) file which includes the results from `qperf-results.txt`
in the reports.

