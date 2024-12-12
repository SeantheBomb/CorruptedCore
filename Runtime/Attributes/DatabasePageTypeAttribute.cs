using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class DatabasePageTypeAttribute : Attribute
{
    // This attribute doesn't need any logic, it's just a marker.
}
