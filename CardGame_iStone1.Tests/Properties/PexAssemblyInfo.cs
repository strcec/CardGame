using System.Web.Mvc;
using Microsoft.Pex.Framework.Using;
// <copyright file="PexAssemblyInfo.cs">Copyright ©  2014</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("CardGame_iStone")]
[assembly: PexInstrumentAssembly("Microsoft.AspNet.Identity.EntityFramework")]
[assembly: PexInstrumentAssembly("System.ComponentModel.DataAnnotations")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Security.Cookies")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("Microsoft.CSharp")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Host.SystemWeb")]
[assembly: PexInstrumentAssembly("EntityFramework")]
[assembly: PexInstrumentAssembly("Owin")]
[assembly: PexInstrumentAssembly("System.Web.Mvc")]
[assembly: PexInstrumentAssembly("System.Web.Optimization")]
[assembly: PexInstrumentAssembly("Microsoft.Owin")]
[assembly: PexInstrumentAssembly("Microsoft.AspNet.Identity.Core")]
[assembly: PexInstrumentAssembly("System.Web")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Security")]
[assembly: PexInstrumentAssembly("Microsoft.AspNet.Identity.Owin")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.AspNet.Identity.EntityFramework")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.ComponentModel.DataAnnotations")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Security.Cookies")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.CSharp")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Host.SystemWeb")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EntityFramework")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Owin")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Mvc")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Optimization")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.AspNet.Identity.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Security")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.AspNet.Identity.Owin")]
[assembly: PexUseType(typeof(IView), "System.Web.Mvc.DependencyResolver+CacheDependencyResolver")]

