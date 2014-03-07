@echo off
mkdir ".\Release\itraderclient2"
mkdir ".\Release\itraderclient2\Plugins"

copy "iTrader.Client2\bin\Release\iTrader.Client2.exe" 			".\Release\itraderclient2\iTrader.Client2.exe"
copy "itcDatabase\bin\Release\System.Data.SqlServerCe.dll" 		".\Release\itraderclient2\System.Data.SqlServerCe.dll"
copy "Plugins\ConsumedOrders\bin\Release\ConsumedOrders.dll" 		".\Release\itraderclient2\Plugins\ConsumedOrders.dll"
copy "Plugins\ReportApplication\bin\Release\ReportApplication.dll" 	".\Release\itraderclient2\Plugins\ReportApplication.dll"
copy "Plugins\GPSShopBinder\bin\Release\GPSShopBinder.dll" 		".\Release\itraderclient2\Plugins\GPSShopBinder.dll"
copy "itcInterface\bin\Release\itcInterface.dll" 			".\Release\itraderclient2\itcInterface.dll"
copy "itcClassess\bin\Release\itcClassess.dll" 				".\Release\itraderclient2\itcClassess.dll"
copy "itcDatabase\bin\Release\itcDatabase.dll" 				".\Release\itraderclient2\itcDatabase.dll"
copy "NetworkLib\bin\Release\NetworkLib.dll" 				".\Release\itraderclient2\NetworkLib.dll"
copy "itcConfig\bin\Release\itcConfig.dll" 				".\Release\itraderclient2\itcConfig.dll"
copy "itcLog\bin\Release\itcLog.dll" 					".\Release\itraderclient2\itcLog.dll"
copy "assemblies\sqlceca35.dll" 		".\Release\itraderclient2\sqlceca35.dll"
copy "assemblies\sqlcecompact35.dll" 	".\Release\itraderclient2\sqlcecompact35.dll"
copy "assemblies\sqlceme35.dll" 	".\Release\itraderclient2\sqlceme35.dll"
copy "assemblies\sqlceoledb35.dll" 	".\Release\itraderclient2\sqlceoledb35.dll"
copy "assemblies\sqlceqp35.dll" 	".\Release\itraderclient2\sqlceqp35.dll"
copy "assemblies\sqlcese35.dll" 	".\Release\itraderclient2\sqlcese35.dll"
copy "assemblies\ICSharpCode.SharpZipLib.dll" 	".\Release\itraderclient2\ICSharpCode.SharpZipLib.dll"

pause