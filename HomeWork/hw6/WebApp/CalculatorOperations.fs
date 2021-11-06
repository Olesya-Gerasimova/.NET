namespace WebApp

module public CalculatorOperations =
    [<Literal>]
    let Addition = "add"

    [<Literal>]
    let Subtract = "sub"

    [<Literal>]
    let Multiply = "mult"

    [<Literal>]
    let Divide = "div"

    [<Literal>]
    let NotIntegerErrorMassage = "The argument is not integer type!"
    
    [<Literal>]
    let DivideByZero = "Division by zero exception!"

    [<Literal>]
    let OperationErrorMassage = "Operation not supported!"

    [<Literal>]
    let ArgumentErrorMassage = "Number of arguments is wrong!"

    [<Literal>]
    let Ok_Code = 0

    [<Literal>]
    let OperationErrorCode = 1

    [<Literal>]
    let NumbersErrorCode = 2

    [<Literal>]
    let ArgumentErrorCode = 3
