namespace Calculator_F_hw5



module public CalculatorOperations =
    [<Literal>]
    let Addition = "+"

    [<Literal>]
    let Subtract = "-"

    [<Literal>]
    let Multiply = "*"

    [<Literal>]
    let Divide = "/"

    [<Literal>]
    let NotIntegerErrorMassage = "exception: The argument is not integer type"
    
    [<Literal>]
    let DivideByZero = "exception: Division by zero"

    [<Literal>]
    let OperationErrorMassage = "exception: Operation is not correct"

    [<Literal>]
    let ArgumentErrorMassage = "exception: wrong number of arguments"

    [<Literal>]
    let Ok_Code = 0

    [<Literal>]
    let OperationErrorCode = 1

    [<Literal>]
    let NumbersErrorCode = 2

    [<Literal>]
    let ArgumentErrorCode = 3
