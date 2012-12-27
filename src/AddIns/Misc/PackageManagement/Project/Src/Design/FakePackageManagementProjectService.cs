﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.PackageManagement;

namespace ICSharpCode.PackageManagement.Design
{
	public class FakePackageManagementProjectService : IPackageManagementProjectService
	{
		public bool IsRefreshProjectBrowserCalled;
		
		public IProject CurrentProject { get; set; }
		public Solution OpenSolution { get; set; }
		
		public event ProjectEventHandler ProjectAdded;
		public event SolutionFolderEventHandler SolutionFolderRemoved;
		public event EventHandler SolutionClosed;
		public event EventHandler<SolutionEventArgs> SolutionLoaded;
		
		public void RefreshProjectBrowser()
		{
			IsRefreshProjectBrowserCalled = true;
		}		
		
		public void FireProjectAddedEvent(IProject project)
		{
			if (ProjectAdded != null) {
				ProjectAdded(this, new ProjectEventArgs(project));
			}
		}
		
		public void FireSolutionClosedEvent()
		{
			if (SolutionClosed != null) {
				SolutionClosed(this, new EventArgs());
			}
		}
		
		public void FireSolutionLoadedEvent(Solution solution)
		{
			if (SolutionLoaded != null) {
				SolutionLoaded(this, new SolutionEventArgs(solution));
			}
		}
		
		public void FireSolutionFolderRemoved(ISolutionFolder solutionFolder)
		{
			if (SolutionFolderRemoved != null) {
				SolutionFolderRemoved(this, new SolutionFolderEventArgs(solutionFolder));
			}
		}
		
		public List<IProject> FakeOpenProjects = new List<IProject>();
		
		public void AddFakeProject(IProject project)
		{
			FakeOpenProjects.Add(project);
		}
		
		public IEnumerable<IProject> GetOpenProjects()
		{
			return FakeOpenProjects;
		}
		
		public void AddProjectItem(IProject project, ProjectItem item)
		{
			ProjectService.AddProjectItem(project, item);
		}
		
		public void RemoveProjectItem(IProject project, ProjectItem item)
		{
			ProjectService.RemoveProjectItem(project, item);
		}
		
		public void Save(IProject project)
		{
			project.Save();
		}
	}
}
