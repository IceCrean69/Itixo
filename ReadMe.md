# Weather Station ETL Service

Táto .NET konzolová aplikácia slúži na automatizovaný zber dát z meteostanice vo formáte XML. Každú hodinu sťahuje aktuálne údaje z URL, transformuje ich do formátu JSON a ukladá do MySQL databázy, pričom korektne ošetruje a loguje aj stavy, kedy je stanica nedostupná.

## Požiadavky a spustenie
- **Nástroje:** .NET 6.0 SDK+, MySQL Server.
- **Príprava:** V MySQL vytvorte databázu `weather_logs` a tabuľku pomocou priloženého SQL skriptu nižšie.
- **Konfigurácia:** V `Program.cs` upravte premennú `conn` (Connection String).
- **Spustenie:** Príkazom `dotnet run` v koreňovom priečinku projektu.

## SQL Schéma
```sql
CREATE TABLE `weatherlogs` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `downloadedAt` DATETIME NOT NULL,
  `isSuccess` BIT NOT NULL,
  `jsonData` JSON NULL,
  `errorMessage` TEXT NULL
);