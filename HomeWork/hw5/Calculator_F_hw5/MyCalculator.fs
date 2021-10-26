namespace Calculator_F_hw5

open System
open CalculatorOperations

type ErrorBuilder() =

    member this.Bind(x, f) =
        match x with
        | Ok x -> f x
        | Error _ -> x

    member b.Combine(x, f) = f x

    member this.Return(x) = Ok x

module public MyCalculator =
    let SetError (error: string) = printfn $"%s{error}"

    let maybe = ErrorBuilder()

    let CheckNumber (a: String) =
        let f, _ = Decimal.TryParse a

        if f = true then
            Ok Ok_Code
        else
            SetError(NotIntegerErrorMassage)
            Error NumbersErrorCode
            
    let CheckNumberTwo (a:String, op:String) =
        let f,r = Decimal.TryParse a
        
        if op.Equals(Divide) && int r = 0 then
            SetError(DivideByZero)
            Error NumbersErrorCode
        else if f = true then
            Ok Ok_Code
        else
            SetError(NotIntegerErrorMassage)
            Error NumbersErrorCode

    let CheckOperation (operation: String) =
        match operation with
        | Addition
        | Subtract
        | Multiply
        | Divide -> Ok Ok_Code
        | _ ->
            SetError(OperationErrorMassage)
            Error OperationErrorCode

    let Add (val1: string, val2: string) : int =
        let r = Decimal.Parse val1 + Decimal.Parse val2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Sub (val1: string, val2: string) : int =
        let r = Decimal.Parse val1 - Decimal.Parse val2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Mult (val1: string, val2: string) : int =
        let r = Decimal.Parse val1 * Decimal.Parse val2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Div (val1: string, val2: string) : int =
        let r = Decimal.Parse val1 / Decimal.Parse val2
        let result = "Result = " + r.ToString("G29")
        printfn $"{result}"
        Ok_Code

    let Proces (num1: string, oper: string, num2: string) : int =
        match oper with
        | Addition -> Add(num1, num2)
        | Subtract -> Sub(num1, num2)
        | Multiply -> Mult(num1, num2)
        | Divide -> Div(num1, num2)
        | _ -> failwith "todo"

    let getCodeForReturn (num1: String, op: String, num2: String) : Result<int, int> =
        maybe {
            let! _num1 = CheckNumber num1
            let! _opr = CheckOperation op
            let! _num2 = CheckNumberTwo(num2,op)
            return Proces(num1, op, num2)
        }
