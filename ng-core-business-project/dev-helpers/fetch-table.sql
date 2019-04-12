
SELECT 
T.TourId, T.BandId, T.Title, T.[Description], T.StartDate, T.EndDate, T.EstimatedProfits,
T.ManagerId, T.CreatedOn, T.CreatedBy, T.UpdatedOn, T.UpdatedBy,
M.ManagerId, M.Name, B.BandId, B.Name 
FROM 
    Tours T 
    INNER JOIN Managers M ON M.ManagerId = T.ManagerId
    INNER JOIN Bands B ON B.BandId = T.BandId
