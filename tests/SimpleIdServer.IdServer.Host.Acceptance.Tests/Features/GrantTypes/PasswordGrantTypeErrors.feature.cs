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
namespace SimpleIdServer.IdServer.Host.Acceptance.Tests.Features.GrantTypes
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class PasswordGrantTypeErrorsFeature : object, Xunit.IClassFixture<PasswordGrantTypeErrorsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "PasswordGrantTypeErrors.feature"
#line hidden
        
        public PasswordGrantTypeErrorsFeature(PasswordGrantTypeErrorsFeature.FixtureData fixtureData, SimpleIdServer_IdServer_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GrantTypes", "PasswordGrantTypeErrors", "\tCheck errors returned when using \'password\' grant-type", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password\' with no username parameter")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password\' with no username parameter")]
        public void SendGrant_TypePasswordWithNoUsernameParameter()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password\' with no username parameter", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table128 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table128.AddRow(new string[] {
                            "grant_type",
                            "password"});
#line 5
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table128, "When ");
#line hidden
#line 9
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
 testRunner.And("JSON \'$.error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 12
 testRunner.And("JSON \'$.error_description\'=\'missing parameter username\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user\' with no password parameter")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user\' with no password parameter")]
        public void SendGrant_TypePasswordUsernameUserWithNoPasswordParameter()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user\' with no password parameter", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table129 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table129.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table129.AddRow(new string[] {
                            "username",
                            "user"});
#line 15
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table129, "When ");
#line hidden
#line 20
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.And("JSON \'$.error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And("JSON \'$.error_description\'=\'missing parameter password\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user,password=pwd,client_id=firstClient,client" +
            "_secret=password\' with unauthorized grant_type")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user,password=pwd,client_id=firstClient,client" +
            "_secret=password\' with unauthorized grant_type")]
        public void SendGrant_TypePasswordUsernameUserPasswordPwdClient_IdFirstClientClient_SecretPasswordWithUnauthorizedGrant_Type()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user,password=pwd,client_id=firstClient,client" +
                    "_secret=password\' with unauthorized grant_type", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 25
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table130 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table130.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table130.AddRow(new string[] {
                            "username",
                            "user"});
                table130.AddRow(new string[] {
                            "password",
                            "pwd"});
                table130.AddRow(new string[] {
                            "client_id",
                            "firstClient"});
                table130.AddRow(new string[] {
                            "client_secret",
                            "password"});
#line 26
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table130, "When ");
#line hidden
#line 34
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.And("JSON \'$.error\'=\'invalid_client\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 37
 testRunner.And("JSON \'$.error_description\'=\'grant type password is not supported by the client\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password\' with duplicate scopes")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password\' with duplicate scopes")]
        public void SendGrant_TypePasswordUsernameUserPasswordPwdClient_IdSecondClientClient_SecretPasswordWithDuplicateScopes()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
                    "t_secret=password\' with duplicate scopes", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                TechTalk.SpecFlow.Table table131 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table131.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table131.AddRow(new string[] {
                            "username",
                            "user"});
                table131.AddRow(new string[] {
                            "password",
                            "pwd"});
                table131.AddRow(new string[] {
                            "client_id",
                            "secondClient"});
                table131.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table131.AddRow(new string[] {
                            "scope",
                            "scope scope"});
#line 40
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table131, "When ");
#line hidden
#line 49
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And("JSON \'$.error\'=\'invalid_scope\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And("JSON \'$.error_description\'=\'duplicate scopes : scope\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password\' with invalid scope")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password\' with invalid scope")]
        public void SendGrant_TypePasswordUsernameUserPasswordPwdClient_IdSecondClientClient_SecretPasswordWithInvalidScope()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
                    "t_secret=password\' with invalid scope", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table132 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table132.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table132.AddRow(new string[] {
                            "username",
                            "user"});
                table132.AddRow(new string[] {
                            "password",
                            "pwd"});
                table132.AddRow(new string[] {
                            "client_id",
                            "secondClient"});
                table132.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table132.AddRow(new string[] {
                            "scope",
                            "scope"});
#line 55
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table132, "When ");
#line hidden
#line 64
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.And("JSON \'$.error\'=\'invalid_scope\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("JSON \'$.error_description\'=\'unauthorized to scopes : scope\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password,scope=firstScope\' with bad user login")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password,scope=firstScope\' with bad user login")]
        public void SendGrant_TypePasswordUsernameUserPasswordPwdClient_IdSecondClientClient_SecretPasswordScopeFirstScopeWithBadUserLogin()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
                    "t_secret=password,scope=firstScope\' with bad user login", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 69
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table133 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table133.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table133.AddRow(new string[] {
                            "username",
                            "badUser"});
                table133.AddRow(new string[] {
                            "password",
                            "badPwd"});
                table133.AddRow(new string[] {
                            "client_id",
                            "secondClient"});
                table133.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table133.AddRow(new string[] {
                            "scope",
                            "firstScope"});
#line 70
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table133, "When ");
#line hidden
#line 79
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 80
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
 testRunner.And("JSON \'$.error\'=\'invalid_grant\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And("JSON \'$.error_description\'=\'bad user credential\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password,scope=firstScope\' with bad user password")]
        [Xunit.TraitAttribute("FeatureTitle", "PasswordGrantTypeErrors")]
        [Xunit.TraitAttribute("Description", "Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
            "t_secret=password,scope=firstScope\' with bad user password")]
        public void SendGrant_TypePasswordUsernameUserPasswordPwdClient_IdSecondClientClient_SecretPasswordScopeFirstScopeWithBadUserPassword()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send \'grant_type=password,username=user,password=pwd,client_id=secondClient,clien" +
                    "t_secret=password,scope=firstScope\' with bad user password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 84
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table134 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table134.AddRow(new string[] {
                            "grant_type",
                            "password"});
                table134.AddRow(new string[] {
                            "username",
                            "user"});
                table134.AddRow(new string[] {
                            "password",
                            "badPwd"});
                table134.AddRow(new string[] {
                            "client_id",
                            "secondClient"});
                table134.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table134.AddRow(new string[] {
                            "scope",
                            "firstScope"});
#line 85
 testRunner.When("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table134, "When ");
#line hidden
#line 94
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 95
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 96
 testRunner.And("JSON \'$.error\'=\'invalid_grant\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.And("JSON \'$.error_description\'=\'bad user credential\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                PasswordGrantTypeErrorsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PasswordGrantTypeErrorsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
