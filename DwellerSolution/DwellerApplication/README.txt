MIGRATION RESET COMMANDO


F�r att ta bort:
Update-database -Migration 0 (tar bort allt inneh�ll)
remove-migration

Starta om:
add-migration InitialCreate
update-database
