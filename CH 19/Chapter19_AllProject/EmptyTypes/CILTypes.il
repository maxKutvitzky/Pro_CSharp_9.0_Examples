.assembly extern System.Runtime
{
 .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
 .ver 5:0:0:0
}
// Our assembly.
.assembly CILTypes 
{
.ver 1:0:0:0
}
// The module of our single-file assembly.
.module CILTypes.dll
// Our assembly has a single namespace.
.namespace MyNamespace 
{
 	// System.Object base class assumed.
 	.class public MyBaseClass 
	{

	}
	// An interface definition.
 	.class public interface IMyInterface 
	{

	}
	// MyDerivedClass now implements IMyInterface, and extends MyBaseClass.
 	.class public MyDerivedClass extends MyNamespace.MyBaseClass implements MyNamespace.IMyInterface 
	{

	}
	// Shorthand notation for declaring a structure.
	.class public sealed value MyStruct
	{
	
	}
	// Enum shorthand.
	.class public sealed enum MyEnum
	{

	}
}
// Defining a nested namespace.
.namespace MyCompany.MyNamespace {}