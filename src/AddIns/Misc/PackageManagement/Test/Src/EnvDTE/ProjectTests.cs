﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.PackageManagement.EnvDTE;
using ICSharpCode.SharpDevelop.Project;
using NUnit.Framework;
using PackageManagement.Tests.Helpers;

namespace PackageManagement.Tests.EnvDTE
{
	[TestFixture]
	public class ProjectTests
	{
		Project project;
		TestableProject msbuildProject;
		
		void CreateProject()
		{
			msbuildProject = ProjectHelper.CreateTestProject();
			project = new Project(msbuildProject);
		}
		
		[Test]
		public void Name_ProjectNameIsMyApp_ReturnsMyApp()
		{
			CreateProject();
			msbuildProject.Name = "MyApp";
			
			string name = project.Name;
			
			Assert.AreEqual("MyApp", name);
		}
		
		[Test]
		public void FullName_ProjectFileNameIsSet_ReturnsFullFileName()
		{
			CreateProject();
			string expectedFullName = @"d:\projects\myproject\myproject.csproj";
			msbuildProject.FileName = expectedFullName;
			
			string fullName = project.FullName;
			
			Assert.AreEqual(expectedFullName, fullName);
		}
		
		[Test]
		public void FileName_ProjectFileNameIsSet_ReturnsFullFileName()
		{
			CreateProject();
			string expectedFileName = @"d:\projects\myproject\myproject.csproj";
			msbuildProject.FileName = expectedFileName;
			
			string fileName = project.FileName;
			
			Assert.AreEqual(expectedFileName, fileName);
		}
		
		[Test]
		public void Type_ProjectIsCSharpProject_ReturnsCSharp()
		{
			CreateProject();
			msbuildProject.FileName = @"c:\projects\myproject\test.csproj";
			
			string projectType = project.Type;
			
			Assert.AreEqual("C#", projectType);
		}
		
		[Test]
		public void Type_ProjectIsCSharpProjectWithFileNameInUpperCase_ReturnsCSharp()
		{
			CreateProject();
			msbuildProject.FileName = @"c:\projects\myproject\TEST.CSPROJ";
			
			string projectType = project.Type;
			
			Assert.AreEqual("C#", projectType);
		}
		
		[Test]
		public void Type_ProjectIsVBProject_ReturnsVBNet()
		{
			CreateProject();
			msbuildProject.FileName = @"c:\projects\myproject\test.vbproj";
			
			string projectType = project.Type;
			
			Assert.AreEqual("VB.NET", projectType);
		}
	}
}
