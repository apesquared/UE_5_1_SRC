// Copyright Epic Games, Inc. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gauntlet;
using System.IO;
using System.IO.Compression;
using EpicGame;

namespace UnrealGame
{

	/// <summary>
	/// Runs automated tests on a platform
	/// </summary>
	public class PGETest : UnrealTestNode<EpicGameTestConfig>
	{
		public PGETest(Gauntlet.UnrealTestContext InContext)
			: base(InContext)
		{
		}

		public override EpicGameTestConfig GetConfiguration()
		{
			EpicGameTestConfig Config = base.GetConfiguration();
			Config.PreAssignAccount = false;
			Config.NoMCP = true;
			UnrealTestRole Server = Config.RequireRole(UnrealTargetRole.Server);
			IEnumerable<UnrealTestRole> Clients = Config.RequireRoles(UnrealTargetRole.Client, 2);
			//Server.Controllers.Add("GauntletTestController");
			Server.CommandLine += " -log";
			//Clients.ElementAt(0).CommandLine += " -log";
			//Clients.ElementAt(0).Controllers.Add("GauntletTestController");
			//Clients.ElementAt(1).CommandLine += " -log";
			Clients.ElementAt(0).MapOverride = "127.0.0.1:7777";
			Clients.ElementAt(1).MapOverride = "127.0.0.1:7777";
			return Config;
			
		}

		public override ITestReport CreateReport(TestResult Result, UnrealTestContext Contex, UnrealBuildSource Build, IEnumerable<UnrealRoleResult> RoleResults, string ArtifactPath)
		{
			UnrealRoleArtifacts ClientArtifacts = RoleResults.Where(R => R.Artifacts.SessionRole.RoleType == UnrealTargetRole.Client).Select(R => R.Artifacts).FirstOrDefault();

			var SnapshotSummary = new UnrealSnapshotSummary<UnrealHealthSnapshot>(ClientArtifacts.AppInstance.StdOut);

			Log.Info("PGE Performance Report");
			Log.Info(SnapshotSummary.ToString());

			return base.CreateReport(Result, Contex, Build, RoleResults, ArtifactPath);
		}

		public override void SaveArtifacts_DEPRECATED(string OutputPath)
		{
			string UploadFolder = Globals.Params.ParseValue("uploadfolder", "");
			if (UploadFolder.Count() > 0 && Directory.CreateDirectory(UploadFolder).Exists)
			{
				string PlatformString = TestInstance.ClientApps[0].Device.Platform.ToString();
				string ArtifactDir = TestInstance.ClientApps[0].ArtifactPath;
				string ProfilingDir = Path.Combine(ArtifactDir, "Profiling");
				string FPSChartsDir = Path.Combine(ProfilingDir, "FPSChartStats").ToLower();
				string FpsChartsZipPath = Path.Combine(TestInstance.ClientApps[0].ArtifactPath, "FPSCharts.zip").ToLower();
				if (Directory.Exists(FPSChartsDir))
				{
					ZipFile.CreateFromDirectory(FPSChartsDir, FpsChartsZipPath);
					string DestFileName = "PGETest-" + PlatformString + ".zip";
					string DestZipFile = Path.Combine(UploadFolder, DestFileName);
					File.Copy(FpsChartsZipPath, DestZipFile);
				}
			}
			else
			{
				Log.Info("Not uploading CSV Result UploadFolder: '" + UploadFolder + "'");
			}
		}
	}
}
