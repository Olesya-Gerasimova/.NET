// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type Program() =
    static member Main(args : string[]) = 
        if args.Length > 3
        then failwith "Wrong number of arguments >3"
        let a : int = int32 args.[0]
        let b : int = int32 args.[2]
        let addition x y = x + y
        let subtraction x y = x - y
        let multiply x y = x * y
        let divide x y = x / y
        match args.[1] with
        | "+" -> printfn($"The result is: %d{addition a b}")
        | "-" -> printfn($"The result is: %d{subtraction a b}")
        | "*" -> printfn($"The result is: %d{multiply a b}")
        | "/" -> printfn($"The result is: %d{divide a b}")
        | _ -> failwith "Unsupported operation type"

module Program__run =
    [<EntryPoint>]
    let main args = 
        Program.Main (args)
        0        
