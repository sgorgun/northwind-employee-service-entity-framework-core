﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthwindEmployeeEfCoreService.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NorthwindEmployeeEfCoreService.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Employees (Id INTEGER PRIMARY KEY, LastName TEXT, FirstName TEXT, Title TEXT, TitleOfCourtesy TEXT, BirthDate DATETIME, HireDate DATETIME, Address TEXT, City TEXT, Region TEXT, PostalCode TEXT, Country TEXT, HomePhone TEXT, Extension TEXT, Notes TEXT, ReportsTo INTEGER, PhotoPath TEXT, FOREIGN KEY (ReportsTo) REFERENCES Employees (Id) ON DELETE CASCADE ON UPDATE NO ACTION);.
        /// </summary>
        internal static string CreateEmployeesTable {
            get {
                return ResourceManager.GetString("CreateEmployeesTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO Employees VALUES (2,&apos;Fuller&apos;,&apos;Andrew&apos;,&apos;Vice President, Sales&apos;,&apos;Dr.&apos;,&apos;02/19/1952&apos;,&apos;08/14/1992&apos;,&apos;908 W. Capital Way&apos;,&apos;Tacoma&apos;,&apos;WA&apos;,&apos;98401&apos;,&apos;USA&apos;,&apos;(206) 555-9482&apos;,&apos;3457&apos;,&apos;Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a me [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InitializeTable {
            get {
                return ResourceManager.GetString("InitializeTable", resourceCulture);
            }
        }
    }
}
