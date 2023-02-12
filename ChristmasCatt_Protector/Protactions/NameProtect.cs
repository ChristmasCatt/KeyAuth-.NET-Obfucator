using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_Project_IdeA.Protactions
{
    internal class NameProtect
    {
        public static void Execute(AssemblyDef assembly, ModuleDef mod)
        {

            foreach (TypeDef type in mod.Types)
            {
                mod.Name = "https://github.com/ChristmasCatt";
                if (type.IsGlobalModuleType || type.IsRuntimeSpecialName || type.IsSpecialName || type.IsWindowsRuntime || type.IsInterface)
                {
                    continue;
                }
                else
                {
                    foreach (PropertyDef property in type.Properties)
                    {
                        if (property.IsRuntimeSpecialName) continue;
                        property.Name = RandomString(20) + "https://github.com/ChristmasCatt";
                    }
                    foreach (FieldDef fields in type.Fields)
                    {
                        fields.Name = RandomString(20) + "https://github.com/ChristmasCatt";
                    }
                    foreach (EventDef eventdef in type.Events)
                    {
                        eventdef.Name = RandomString(20) + "https://github.com/ChristmasCatt";
                    }
                    foreach (MethodDef method in type.Methods)
                    {
                        if (method.IsConstructor || method.IsRuntimeSpecialName || method.IsRuntime || method.IsStaticConstructor || method.IsVirtual) continue;
                        method.Name = RandomString(20);
                    }
                }
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "日本書紀العالمحالعجلة林氏家族การดำน้ำดูปะการังसंस्कृतम्संस्कृतावाक्abcdeiu78ajd76";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
