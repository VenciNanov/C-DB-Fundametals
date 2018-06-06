CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
	RETURNS BIT
AS
	BEGIN
		DECLARE @isCompromised BIT = 0;
		DECLARE @currentIndes INT =1;
		DECLARE @currentChar CHAR;

		WHILE(@currentIndes <=LEN(@word))
		BEGIN
			SET @currentChar = SUBSTRING(@word,@currentIndes,1);
			IF(CHARINDEX(@currentChar,@setOfLetters)=0)
			BEGIN
				RETURN @isCompromised;
			END
		SET @currentIndes +=1;
		END

	RETURN @isCompromised+1;
END

