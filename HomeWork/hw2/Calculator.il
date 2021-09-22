.class public auto ansi beforefieldinit
  hw1.Calculator
    extends [System.Runtime]System.Object
{

  .method public hidebysig instance int32
    Calculate(
      string operation,
      int32 val1,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] int32 result,
      [1] int32 V_1,
      [2] int32 V_2
    )

    // [6 9 - 6 10]
    IL_0000: nop

    // [7 13 - 14 15]
    IL_0001: ldc.i4.1
    IL_0002: brtrue.s     IL_0005

    // [7 36 - 14 14]
    IL_0004: nop

    IL_0005: ldarg.1      // operation
    IL_0006: ldstr        "+"
    IL_000b: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldarg.1      // operation
    IL_0013: ldstr        "-"
    IL_0018: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_0041
    IL_001f: ldarg.1      // operation
    IL_0020: ldstr        "*"
    IL_0025: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0047
    IL_002c: ldarg.1      // operation
    IL_002d: ldstr        "/"
    IL_0032: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_004d
    IL_0039: br.s         IL_0053

    // [9 24 - 9 35]
    IL_003b: ldarg.2      // val1
    IL_003c: ldarg.3      // val2
    IL_003d: add
    IL_003e: stloc.1      // V_1
    IL_003f: br.s         IL_0057

    // [10 24 - 10 35]
    IL_0041: ldarg.2      // val1
    IL_0042: ldarg.3      // val2
    IL_0043: sub
    IL_0044: stloc.1      // V_1
    IL_0045: br.s         IL_0057

    // [11 24 - 11 35]
    IL_0047: ldarg.2      // val1
    IL_0048: ldarg.3      // val2
    IL_0049: mul
    IL_004a: stloc.1      // V_1
    IL_004b: br.s         IL_0057

    // [12 24 - 12 35]
    IL_004d: ldarg.2      // val1
    IL_004e: ldarg.3      // val2
    IL_004f: div
    IL_0050: stloc.1      // V_1
    IL_0051: br.s         IL_0057

    // [13 22 - 13 23]
    IL_0053: ldc.i4.0
    IL_0054: stloc.1      // V_1
    IL_0055: br.s         IL_0057

    IL_0057: ldc.i4.1
    IL_0058: brtrue.s     IL_005b

    // [7 13 - 14 15]
    IL_005a: nop

    IL_005b: ldloc.1      // V_1
    IL_005c: stloc.0      // result

    // [15 13 - 15 27]
    IL_005d: ldloc.0      // result
    IL_005e: stloc.2      // V_2
    IL_005f: br.s         IL_0061

    // [16 9 - 16 10]
    IL_0061: ldloc.2      // V_2
    IL_0062: ret

  } // end of method Calculator::Calculate

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method Calculator::.ctor
} // end of class hw1.Calculator
