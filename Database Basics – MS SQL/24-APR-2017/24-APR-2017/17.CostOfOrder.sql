CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(10,2)
AS
BEGIN
	DECLARE @result DECIMAL(10,2) = (SELECT ISNULL(SUM(p.Price),0.00)
							FROM Jobs AS j
							JOIN Orders AS o ON o.JobId=j.JobId
							JOIN OrderParts AS op ON op.OrderId=o.OrderId
							JOIN Parts AS p ON p.PartId=op.PartId
							WHERE j.JobId=@jobId);

	RETURN @result

END

