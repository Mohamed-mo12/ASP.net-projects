#!/bin/bash
until /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '10203040Medo##' -Q 'SELECT 1'; do
  >&2 echo "SQL Server is starting up"
  sleep 1
done

# Restore the 
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '10203040Medo##' -Q "RESTORE DATABASE [EcommerceDB] FROM DISK = '/var/opt/mssql/backup/EcommerceDB.bak' WITH MOVE 'YourDatabase_Data' TO '/var/opt/mssql/data/EcommerceDB.mdf', MOVE 'YourDatabase_Log' TO '/var/opt/mssql/data/EcommerceDB.ldf'"
