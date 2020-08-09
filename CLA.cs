using System;
using System.Reflection;

namespace Vanity
{
    [AttributeUsage( AttributeTargets.Field, AllowMultiple = false )]
    internal sealed class CommandLineArgumentAttribute : Attribute
    {
        readonly string name;

        public CommandLineArgumentAttribute( string _name )
        {
            name = _name;
        }

        public string GetName()
        {
            return name;
        }
    }

    public static class CLA
    {
        // Look up all fields that have the CLA attribtue attached; read out the name and see if we 
        // match it on the command line anywhere. If so, SetValue() on the instance from the argument string
        public static void Run( Type argContainer, string[] args )
        {
            var staticFields = argContainer.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach ( FieldInfo f in staticFields )
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(f);
                foreach ( Attribute attr in attrs )
                {
                    if ( attr is CommandLineArgumentAttribute )
                    {
                        var clattr = (CommandLineArgumentAttribute)attr;

                        string nameMatch = "-" + clattr.GetName();
                        for ( var i = 0; i < args.Length; i++ )
                        {
                            if ( args[i] == nameMatch )
                            {
                                if ( i + 1 < args.Length )
                                {
                                    f.SetValue( null, args[i + 1] );
                                    i++;
                                }
                                else
                                {
                                    Console.WriteLine( "Command line value not specified for " + clattr.GetName() );
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
