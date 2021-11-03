open System.IO
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open WebApp

let contentRoot = Directory.GetCurrentDirectory()

let CreateHostBuilder (_: string array) =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun webHostBuilder ->
            webHostBuilder
                .UseContentRoot(contentRoot)
                .UseStartup<Startup>()
            |> ignore)


[<EntryPoint>]
let main _ =
    Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(fun webHostBuilder ->
            webHostBuilder
                .UseContentRoot(contentRoot)
                .UseStartup<Startup>()
            |> ignore)
        .Build()
        .Run()

    0
