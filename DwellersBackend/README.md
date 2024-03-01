# Dwellers
App för att underlätta livet som delade hushåll. Riktar sig framförallt mot olika former av kooperativa hushåll i nuvarande version. 

API/backend: C#. EF Core för datamodellering och ev framöver Dapper för mer avancerade queries för query-repositories.
Databas: SQL server
Frontend: React / javascript

Planerade features i närtid för MVP-version:
- Inloggningsfunktionalitet / authenticering
- Husmöten
- To do/ projekt-lista

Planerade features i senare skede:
- Lägga till grannskap. Olika hushåll kan interagera med andra hushåll.
	- Hushåll kan bli "digitala grannar".
	- Kan bjuda in till events (grillkväll mm)
	- Låna / låna ut redskap / tjänster, ordnat i ett system som håller koll på vem som 	lånat vad. 
- Chat inom hushåll eller / och mellan hushåll (med signalR).
- Ekonomi inom hushåll, budget / kvittoshantering mm.
