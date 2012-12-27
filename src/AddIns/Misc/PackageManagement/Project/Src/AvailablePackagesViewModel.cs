﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.Linq;

using NuGet;

namespace ICSharpCode.PackageManagement
{
	public class AvailablePackagesViewModel : PackagesViewModel
	{
		IPackageRepository repository;
		string errorMessage;
		
		public AvailablePackagesViewModel(
			IRegisteredPackageRepositories registeredPackageRepositories,
			IPackageViewModelFactory packageViewModelFactory,
			ITaskFactory taskFactory)
			: base(registeredPackageRepositories, packageViewModelFactory, taskFactory)
		{
			IsSearchable = true;
			ShowPackageSources = registeredPackageRepositories.HasMultiplePackageSources;
		}
		
		protected override void UpdateRepositoryBeforeReadPackagesTaskStarts()
		{
			try {
				repository = RegisteredPackageRepositories.ActiveRepository;
			} catch (Exception ex) {
				errorMessage = ex.Message;
			}
		}
		
		protected override IQueryable<IPackage> GetAllPackages()
		{
			if (repository == null) {
				throw new ApplicationException(errorMessage);
			}
			return repository.GetPackages();
		}
		
		protected override IEnumerable<IPackage> GetFilteredPackagesBeforePagingResults(IQueryable<IPackage> allPackages)
		{
			return base.GetFilteredPackagesBeforePagingResults(allPackages)
				.Where(package => package.IsReleaseVersion())
				.DistinctLast(PackageEqualityComparer.Id);
		}
	}
}
