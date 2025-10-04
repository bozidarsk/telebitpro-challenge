# How to build & run
Use `dotnet run` to run the program. The arguments are passed using stdin in the following format:
- &lt;N&gt; &lt;K&gt;
- &lt;a1&gt; &lt;a2&gt; ... &lt;aN&gt;

## Examples
### Input:
- 15 3
- 666 42 7 13 400 511 600 200 202 111 313 94 280 72 42
### Output:
- 1186

# Performance
With a big input like:
- 15 3
- 666000 42000 7000 13000 400000 511000 600000 200000 202000 111000 313000 94000 280000 72000 42000

when published in Release configuration (`dotnet publish -c release`) the executable located in *bin/Release/net9.0/publish/* has an execution time of **0.58s user 0.02s system 5% cpu 10.110 total**, measured with the GNU time utility program on linux.

