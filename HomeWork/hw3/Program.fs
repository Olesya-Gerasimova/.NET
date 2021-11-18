// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//
open System

type Program() =
    static member Main(args : string[]) = 
        if args.Length > 3
            then failwith "Wrong number of arguments >3"
        
        let TryParseOrQuit (s:string) =
            match Int32.TryParse s with
            | (true, number) -> number
            | _              -> failwith "sorry - you did not enter an integer"
        
        let a : int = TryParseOrQuit args.[0]
        let b : int = TryParseOrQuit args.[2]

        
        let addition x y = x + y
        let subtraction x y = x - y
        let multiply x y = x * y
        let divide x y = x / y
        match args.[1] with
        | "+" -> printfn($"The result is: %d{addition a b}")
        | "-" -> printfn($"The result is: %d{subtraction a b}")
        | "*" -> printfn($"The result is: %d{multiply a b}")
        | "/" ->
            try
                printfn($"The result is: %d{divide a b}")
            with
            | :? DivideByZeroException -> failwith "Cannot divide by 0"
        | _ -> failwith "Unsupported operation type"

module Program__run =
    [<EntryPoint>]
    let main args = 
        Program.Main (args)
        0