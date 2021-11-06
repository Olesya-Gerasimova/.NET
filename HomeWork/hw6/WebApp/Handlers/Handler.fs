module Handler

open System
open WebApp
open Giraffe
open Microsoft.AspNetCore.Http
open Calculator

let responseHandler (result: Decimal) : HttpHandler =
    setStatusCode 200 >=> text $"Result = {result}"


let errorHandler (errorMessage: String) : HttpHandler =
    setStatusCode 500
    >=> text $"The server cannot process your request right now: {errorMessage}. Please try again later"

[<CLIMutable>]
type Parameter =
    { num1: string
      num2: string
      operation: string }

let submitParameter: HttpHandler =
    fun (next: HttpFunc) (ctx: HttpContext) ->
        let pr = ctx.TryBindQueryString<Parameter>()
        match pr with
        | Ok v ->
            let res = getCodeForReturn (v.num1, v.operation, v.num2)

            match res with
            | Ok res -> responseHandler res next ctx
            | Error err -> errorHandler err next ctx
        | Error err -> (setStatusCode 500 >=> json err) next ctx
