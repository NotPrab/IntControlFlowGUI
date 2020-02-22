using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace asfpaifhaipfahfipasfhaipsfashjfpiqsfh190f1hf1ifp1hf1ipf1wf1
{
    // Protection From Meeimy
    internal class IntControlFlow
    {
        public static void Execute(ModuleDef module)
        {
            foreach (TypeDef type in module.GetTypes())
            {
                if (type.IsGlobalModuleType) continue;
                foreach (MethodDef methodDef2 in type.Methods)
                {
                    if (!methodDef2.HasBody) continue;
                    var instr = methodDef2.Body.Instructions;
                    for (int i = 0; i < instr.Count; i++)
                    {
                        if (methodDef2.Body.Instructions[i].IsLdcI4())
                        {
                            int numorig = new Random(Guid.NewGuid().GetHashCode()).Next();
                            int div = new Random(Guid.NewGuid().GetHashCode()).Next();
                            int num = numorig ^ div;

                            Instruction nop = OpCodes.Nop.ToInstruction();

                            Local local = new Local(methodDef2.Module.ImportAsTypeSig(typeof(int)));
                            methodDef2.Body.Variables.Add(local);
                            methodDef2.Body.Instructions.Insert(i + 1, OpCodes.Stloc.ToInstruction(local));
                            methodDef2.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, methodDef2.Body.Instructions[i].GetLdcI4Value() - sizeof(float)));
                            methodDef2.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, num));
                            methodDef2.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, div));
                            methodDef2.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
                            methodDef2.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, numorig));
                            methodDef2.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, nop));
                            methodDef2.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
                            methodDef2.Body.Instructions.Insert(i + 9, OpCodes.Stloc.ToInstruction(local));
                            methodDef2.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, methodDef2.Module.Import(typeof(float))));
                            methodDef2.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
                            methodDef2.Body.Instructions.Insert(i + 12, nop);
                            i += 12;
                        }
                    }
                }
            }
        }
    }
}
