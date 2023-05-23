﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.IdServer.Host.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RequestObjectFeature : object, Xunit.IClassFixture<RequestObjectFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "RequestObject.feature"
#line hidden
        
        public RequestObjectFeature(RequestObjectFeature.FixtureData fixtureData, SimpleIdServer_IdServer_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "RequestObject", "\tPass request object", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Identity Token and authorization code are returned when passing JWS request param" +
            "eter")]
        [Xunit.TraitAttribute("FeatureTitle", "RequestObject")]
        [Xunit.TraitAttribute("Description", "Identity Token and authorization code are returned when passing JWS request param" +
            "eter")]
        public void IdentityTokenAndAuthorizationCodeAreReturnedWhenPassingJWSRequestParameter()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identity Token and authorization code are returned when passing JWS request param" +
                    "eter", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table446 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table446.AddRow(new string[] {
                            "iss",
                            "thirtyOneClient"});
                table446.AddRow(new string[] {
                            "aud",
                            "aud"});
                table446.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table446.AddRow(new string[] {
                            "client_id",
                            "thirtyOneClient"});
                table446.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table446.AddRow(new string[] {
                            "scope",
                            "openid email"});
                table446.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table446.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 6
 testRunner.And("build JWS request object for client \'thirtyOneClient\' and sign with the key \'keyI" +
                        "d\'", ((string)(null)), table446, "And ");
#line hidden
                TechTalk.SpecFlow.Table table447 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table447.AddRow(new string[] {
                            "request",
                            "$request$"});
                table447.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table447.AddRow(new string[] {
                            "client_id",
                            "thirtyOneClient"});
                table447.AddRow(new string[] {
                            "state",
                            "state"});
                table447.AddRow(new string[] {
                            "scope",
                            "openid email"});
#line 17
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table447, "When ");
#line hidden
#line 25
 testRunner.And("extract parameter \'id_token\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.And("extract payload from JWT \'$id_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.Then("redirection url contains the parameter \'code\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 29
 testRunner.Then("redirection url contains the parameter \'id_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.Then("redirection url doesn\'t contain the parameter \'access_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 31
 testRunner.Then("JWT contains \'iss\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.Then("JWT contains \'aud\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.Then("JWT contains \'exp\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
 testRunner.Then("JWT contains \'iat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.Then("JWT contains \'azp\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("JWT contains \'c_hash\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 37
 testRunner.Then("JWT has \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Identity Token and authorization code are returned when passing JWE request param" +
            "eter encrypted with Public Key")]
        [Xunit.TraitAttribute("FeatureTitle", "RequestObject")]
        [Xunit.TraitAttribute("Description", "Identity Token and authorization code are returned when passing JWE request param" +
            "eter encrypted with Public Key")]
        public void IdentityTokenAndAuthorizationCodeAreReturnedWhenPassingJWERequestParameterEncryptedWithPublicKey()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Identity Token and authorization code are returned when passing JWE request param" +
                    "eter encrypted with Public Key", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 40
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table448 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table448.AddRow(new string[] {
                            "iss",
                            "thirtyTwoClient"});
                table448.AddRow(new string[] {
                            "aud",
                            "aud"});
                table448.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table448.AddRow(new string[] {
                            "client_id",
                            "thirtyTwoClient"});
                table448.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table448.AddRow(new string[] {
                            "scope",
                            "openid email"});
                table448.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table448.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 41
 testRunner.And("build JWE request object for client \'thirtyTwoClient\' and sign with the key \'keyI" +
                        "d\' and encrypt with the key \'keyid4\'", ((string)(null)), table448, "And ");
#line hidden
                TechTalk.SpecFlow.Table table449 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table449.AddRow(new string[] {
                            "request",
                            "$request$"});
                table449.AddRow(new string[] {
                            "response_type",
                            "code id_token"});
                table449.AddRow(new string[] {
                            "client_id",
                            "thirtyTwoClient"});
                table449.AddRow(new string[] {
                            "state",
                            "state"});
                table449.AddRow(new string[] {
                            "scope",
                            "openid email"});
#line 52
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table449, "When ");
#line hidden
#line 60
 testRunner.And("extract parameter \'id_token\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 61
 testRunner.And("extract payload from JWT \'$id_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
 testRunner.Then("redirection url contains the parameter \'code\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Then("redirection url contains the parameter \'id_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then("redirection url doesn\'t contain the parameter \'access_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Then("JWT contains \'iss\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 67
 testRunner.Then("JWT contains \'aud\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
 testRunner.Then("JWT contains \'exp\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.Then("JWT contains \'iat\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 70
 testRunner.Then("JWT contains \'azp\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 71
 testRunner.Then("JWT contains \'c_hash\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("JWT has \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RequestObjectFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RequestObjectFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
