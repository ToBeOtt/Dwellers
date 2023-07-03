MIGRATION RESET COMMANDO


För att ta bort:
Update-database -Migration 0 (tar bort allt innehåll)
remove-migration

Starta om:
add-migration InitialCreate
update-database
