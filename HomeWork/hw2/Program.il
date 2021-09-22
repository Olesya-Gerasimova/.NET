.class private auto ansi beforefieldinit
  hw1.Program
    extends [System.Runtime]System.Object
{

  .method private hidebysig static int32
    Main(
      string[] args
    ) cil managed
  {
    .entrypoint
    .maxstack 2
    .locals init (
      [0] int32 V_0
    )

    // [8 9 - 8 10]
    IL_0000: nop

    // [9 13 - 9 58]
    IL_0001: newobj       instance void hw1.CalculatorLauncher::.ctor()
    IL_0006: ldarg.0      // args
    IL_0007: call         instance int32 hw1.CalculatorLauncher::Launch(string[])
    IL_000c: stloc.0      // V_0
    IL_000d: br.s         IL_000f

    // [10 9 - 10 10]
    IL_000f: ldloc.0      // V_0
    IL_0010: ret

  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname instance void
    .ctor() cil managed
  {
    .maxstack 8

    IL_0000: ldarg.0      // this
    IL_0001: call         instance void [System.Runtime]System.Object::.ctor()
    IL_0006: nop
    IL_0007: ret

  } // end of method Program::.ctor
} // end of class hw1.Program
