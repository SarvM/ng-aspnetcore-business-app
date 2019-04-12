SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='TourManagementDB'

-- __EFMigrationsHistory
-- Bands
-- Managers
-- Tours
-- Shows


select ShowId, City, Country, [Date], TourId, Venue, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy from shows; 

select TourId, Title,  [Description],  EstimatedProfits, StartDate, EndDate, BandId,  ManagerId, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy from Tours; 