 exec sp_helpfile

Use [Pss_sg3g]
Alter Database [Pss_sg3g] Set Recovery Simple
DBCC SHRINKFILE ('Pss_sg3g_log', 1)
Alter Database [Pss_sg3g] Set Recovery Full
DBCC SHRINKDATABASE (Pss_sg3g, 10);

exec sp_helpfile