using dnlib.DotNet;

namespace asfpaifhaipfahfipasfhaipsfashjfpiqsfh190f1hf1ifp1hf1ipf1wf1
{
    internal class AssemblyRenaming
    {
        public static void Execute(AssemblyDef ass)
        {
            var ManifestModule = ass.ManifestModule;
            ManifestModule.Name = ("IntControlFlow GUI");
            ManifestModule.Assembly.Name = ("IntControlFlow GUI");
        }
    }
}
