namespace WebApp

open System
open CalculatorOperations

type ErrorBuilder() =

    member this.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error _ -> x

    member b.Combine(x, f) = f x

    member this.Return(x) = Ok x

module public Calculator =
    let SetError (error: string) = printfn $"%s{error}"

    let maybe = ErrorBuilder()

    let CheckNumber (a: String) =
        let t, r = Decimal.TryParse a
        if t = true then
            Ok r
        else
            Error NotIntegerErrorMassage

    let CheckNumberTwo (a: String) =
        let t, r = Decimal.TryParse a
        if t = true then
            Ok r
        else
            Error NotIntegerErrorMassage
            
    let CheckDivisionByZero (operation: String, a: Decimal) =
        if operation.Equals(Divide) && int a = 0 then
            Error DivideByZero
        else Ok a

    let CheckOperation (operation: String, num1: Decimal) =
        match operation with
        | Addition
        | Subtract
        | Multiply
        | Divide -> Ok num1
        | _ -> Error OperationErrorMassage

    let Add (num1: Decimal, num2: Decimal) = num1 + num2
        
    let Sub (num1: Decimal, num2: Decimal) = num1 - num2
        
    let Mult (num1: Decimal, num2: Decimal) = num1 * num2

    let Div (num1: Decimal, num2: Decimal) = num1 / num2

    let Process (num1: Decimal, operation: string, num2: Decimal) : Decimal =
        match operation with
        | Addition -> Add(num1, num2)
        | Subtract -> Sub(num1, num2)
        | Multiply -> Mult(num1, num2)
        | Divide -> Div(num1, num2)
        | _ -> failwith "Not supported Operation!"

    let getCodeForReturn (num1: String, operation: String, num2: String) : Result<Decimal, String> =
        maybe {
            let! num1 = CheckNumber num1
            let! num2 = CheckNumberTwo num2
            let! _operation = CheckOperation(operation, num1)
            let! _divByZero = CheckDivisionByZero(operation, num2)
            return Process(num1, operation, num2)
        }
