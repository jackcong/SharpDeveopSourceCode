﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.ObjectModel;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;

namespace PackageManagement.Tests.Helpers
{
	public class TestableProject : MSBuildBasedProject
	{
		public bool IsSaved;
		
		public ItemType ItemTypeToReturnFromGetDefaultItemType {
			get { return TestableProjectBehaviour.ItemTypeToReturnFromGetDefaultItemType; }
			set { TestableProjectBehaviour.ItemTypeToReturnFromGetDefaultItemType = value; }
		}
		
		public ReadOnlyCollection<ProjectItem> ItemsWhenSaved;
		
		public TestableProject(ProjectCreateInformation createInfo)
			: base(createInfo)
		{
		}
		
		public override void Save(string fileName)
		{
			IsSaved = true;
			ItemsWhenSaved = Items;
		}
		
		public string FileNamePassedToGetDefaultItemType {
			get { return TestableProjectBehaviour.FileNamePassedToGetDefaultItemType; }
		}
		
		public TestableProjectBehaviour TestableProjectBehaviour = new TestableProjectBehaviour();
		
		protected override ProjectBehavior GetOrCreateBehavior()
		{
			return TestableProjectBehaviour;
		}
		
		public ReferenceProjectItem AddReference(string include)
		{
			var referenceProjectItem = new ReferenceProjectItem(this, include);
			ProjectService.AddProjectItem(this, referenceProjectItem);
			return referenceProjectItem;
		}
		
		public FileProjectItem AddFile(string include)
		{
			var fileProjectItem = new FileProjectItem(this, ItemType.Compile, include);
			ProjectService.AddProjectItem(this, fileProjectItem);
			return fileProjectItem;
		}
		
		public FileProjectItem AddDirectory(string include)
		{
			var fileProjectItem = new FileProjectItem(this, ItemType.Folder, include);
			ProjectService.AddProjectItem(this, fileProjectItem);
			return fileProjectItem;			
		}
	}
}
