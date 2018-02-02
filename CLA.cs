using System;
using System.Reflection;

namespace Vanity
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CommandLineArgumentAttribute : Attribute
    {
        String name;

        public CommandLineArgumentAttribute(String _name)
        {
            name = _name;
        }

        public string GetName()
        {
            return name;
        }
    }

    public class CLA
    {
        public static void run(Type argContainer, string[] args)
        {
            var staticFields = argContainer.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (FieldInfo f in staticFields)
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(f);
                foreach (Attribute attr in attrs)
                {
                    if (attr is CommandLineArgumentAttribute)
                    {
                        CommandLineArgumentAttribute clattr = (CommandLineArgumentAttribute)attr;

                        String nameMatch = "-" + clattr.GetName();
                        for (var i = 0; i < args.Length; i++)
                        {
                            if (args[i] == nameMatch)
                            {
                                if (i + 1 < args.Length)
                                {
                                    f.SetValue(null, args[i + 1]);
                                    i++;
                                }
                                else
                                {
                                    Console.WriteLine("Command line value not specified for " + clattr.GetName());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
