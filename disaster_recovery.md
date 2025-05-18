## Disaster Recovery

System tworzy automatyczne kopie zapasowe bazy danych `poziomka` przy pomocy `sqlcmd`, a skrypt `backup_poziomka.sh` uruchamiany jest cyklicznie przez `cron`. Kopie zapisywane są na serwerze, a dodatkowo będą replikowane do innego regionu (S3).

### RTO (Recovery Time Objective): 30 minut
Czas potrzebny na odtworzenie aplikacji oraz przywrócenie bazy danych z backupu to około 30 minut, ponieważ wystarczy uruchomić gotową instancję EC2 i odtworzyć `.bak`.

### RPO (Recovery Point Objective): 1 dzień
Backup wykonywany raz dziennie, więc maksymalna strata danych to 24 godziny. JEst wykonywany Codzienie o godzinie 2 w nocy

