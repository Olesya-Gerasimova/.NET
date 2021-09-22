.class public auto ansi beforefieldinit
  hw1.CalculatorLauncher
    extends [System.Runtime]System.Object
{

  .field private static literal int32 WrongArgumentLength = int32(1) // 0x00000001

  .field private static literal int32 WrongArgFormat = int32(2) // 0x00000002

  .field private static literal int32 WrongCalculation = int32(3) // 0x00000003

  .method public hidebysig instance int32
    Launch(
      string[] args
    ) cil managed
  {
    .maxstack 4
    .locals init (
      [0] string operation,
      [1] int32 val1,
      [2] int32 val2,
      [3] bool V_3,
      [4] int32 V_4,
      [5] bool V_5,
      [6] int32 result
    )

    // [12 9 - 12 10]
    IL_0000: nop

    // [13 13 - 13 38]
    IL_0001: ldarg.1      // args
    IL_0002: call         bool hw1.CalculatorLauncher::CheckArgLength(string[])
    IL_0007: stloc.3      // V_3

    IL_0008: ldloc.3      // V_3
    IL_0009: brfalse.s    IL_0011

    // [14 13 - 14 14]
    IL_000b: nop

    // [15 17 - 15 44]
    IL_000c: ldc.i4.1
    IL_000d: stloc.s      V_4
    IL_000f: br.s         IL_007c

    // [18 13 - 18 37]
    IL_0011: ldarg.1      // args
    IL_0012: ldc.i4.1
    IL_0013: ldelem.ref
    IL_0014: stloc.0      // operation

    // [19 13 - 20 58]
    IL_0015: ldarg.1      // args
    IL_0016: ldc.i4.0
    IL_0017: ldelem.ref
    IL_0018: ldloca.s     val1
    IL_001a: call         bool hw1.CalculatorLauncher::TryParseOrQuit(string, int32&)
    IL_001f: brtrue.s     IL_002d
    IL_0021: ldarg.1      // args
    IL_0022: ldc.i4.2
    IL_0023: ldelem.ref
    IL_0024: ldloca.s     val2
    IL_0026: call         bool hw1.CalculatorLauncher::TryParseOrQuit(string, int32&)
    IL_002b: br.s         IL_002e
    IL_002d: ldc.i4.1
    IL_002e: stloc.s      V_5

    IL_0030: ldloc.s      V_5
    IL_0032: brfalse.s    IL_003a

    // [21 13 - 21 14]
    IL_0034: nop

    // [22 17 - 22 39]
    IL_0035: ldc.i4.2
    IL_0036: stloc.s      V_4
    IL_0038: br.s         IL_007c

    IL_003a: nop
    .try
    {

      // [26 13 - 26 14]
      IL_003b: nop

      // [27 17 - 27 80]
      IL_003c: newobj       instance void hw1.Calculator::.ctor()
      IL_0041: ldloc.0      // operation
      IL_0042: ldloc.1      // val1
      IL_0043: ldloc.2      // val2
      IL_0044: call         instance int32 hw1.Calculator::Calculate(string, int32, int32)
      IL_0049: stloc.s      result

      // [28 17 - 28 59]
      IL_004b: ldstr        "Result is: {0}"
      IL_0050: ldloc.s      result
      IL_0052: box          [System.Runtime]System.Int32
      IL_0057: call         string [System.Runtime]System.String::Format(string, object)
      IL_005c: call         void [System.Console]System.Console::WriteLine(string)
      IL_0061: nop

      // [29 13 - 29 14]
      IL_0062: nop
      IL_0063: leave.s      IL_0077
    } // end of .try
    catch [System.Runtime]System.DivideByZeroException
    {

      // [30 13 - 30 42]
      IL_0065: pop

      // [31 13 - 31 14]
      IL_0066: nop

      // [32 17 - 32 79]
      IL_0067: ldstr        "Can't divide to zero! Invalid arguments."
      IL_006c: call         void [System.Console]System.Console::WriteLine(string)
      IL_0071: nop

      // [33 17 - 33 41]
      IL_0072: ldc.i4.3
      IL_0073: stloc.s      V_4
      IL_0075: leave.s      IL_007c
    } // end of catch

    // [36 13 - 36 22]
    IL_0077: ldc.i4.0
    IL_0078: stloc.s      V_4
    IL_007a: br.s         IL_007c

    // [37 9 - 37 10]
    IL_007c: ldloc.s      V_4
    IL_007e: ret

  } // end of method CalculatorLauncher::Launch

  .method private hidebysig static bool
    TryParseOrQuit(
      string arg,
      [out] int32& val1
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool isVal1,
      [1] bool V_1,
      [2] bool V_2
    )

    // [40 9 - 40 10]
    IL_0000: nop

    // [41 13 - 41 54]
    IL_0001: ldarg.0      // arg
    IL_0002: ldarg.1      // val1
    IL_0003: call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    IL_0008: stloc.0      // isVal1

    // [42 13 - 42 24]
    IL_0009: ldloc.0      // isVal1
    IL_000a: stloc.1      // V_1

    IL_000b: ldloc.1      // V_1
    IL_000c: brfalse.s    IL_0013

    // [43 13 - 43 14]
    IL_000e: nop

    // [44 17 - 44 30]
    IL_000f: ldc.i4.0
    IL_0010: stloc.2      // V_2
    IL_0011: br.s         IL_0029

    // [47 13 - 47 59]
    IL_0013: ldstr        "Value is not int: "
    IL_0018: ldarg.0      // arg
    IL_0019: call         string [System.Runtime]System.String::Concat(string, string)
    IL_001e: call         void [System.Console]System.Console::WriteLine(string)
    IL_0023: nop

    // [48 13 - 48 14]
    IL_0024: nop

    // [49 17 - 49 29]
    IL_0025: ldc.i4.1
    IL_0026: stloc.2      // V_2
    IL_0027: br.s         IL_0029

    // [52 9 - 52 10]
    IL_0029: ldloc.2      // V_2
    IL_002a: ret

  } // end of method CalculatorLauncher::TryParseOrQuit

  .method private hidebysig static bool
    CheckArgLength(
      string[] args
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )

    // [55 9 - 55 10]
    IL_0000: nop

    // [56 13 - 56 33]
    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: cgt
    IL_0007: stloc.0      // V_0

    IL_0008: ldloc.0      // V_0
    IL_0009: brfalse.s    IL_0032

    // [57 13 - 57 14]
    IL_000b: nop

    // [58 17 - 60 68]
    IL_000c: ldstr        "The program requires 3 "
    IL_0011: ldstr        "CLI arguments but {0} provided"
    IL_0016: ldarg.0      // args
    IL_0017: ldlen
    IL_0018: conv.i4
    IL_0019: box          [System.Runtime]System.Int32
    IL_001e: call         string [System.Runtime]System.String::Format(string, object)
    IL_0023: call         string [System.Runtime]System.String::Concat(string, string)
    IL_0028: call         void [System.Console]System.Console::WriteLine(string)
    IL_002d: nop

    // [61 17 - 61 29]
    IL_002e: ldc.i4.1
    IL_002f: stloc.1      // V_1
    IL_0030: br.s         IL_0036

    // [63 13 - 63 26]
    IL_0032: ldc.i4.0
    IL_0033: stloc.1      // V_1
    IL_0034: br.s         IL_0036

    // [64 9 - 64 10]
    IL_0036: ldloc.1      // V_1
    IL_0037: ret

  } // end of method CalculatorLauncher::CheckArgLength

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method CalculatorLauncher::.ctor
} // end of class hw1.CalculatorLauncher
