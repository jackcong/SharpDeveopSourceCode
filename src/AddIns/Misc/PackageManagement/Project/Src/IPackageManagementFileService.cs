﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;

namespace ICSharpCode.PackageManagement
{
	public interface IPackageManagementFileService
	{
		void RemoveFile(string path);
		void RemoveDirectory(string path);
		void OpenFile(string fileName);
		void CopyFile(string oldFileName, string newFileName);
		bool FileExists(string fileName);
	}
}
