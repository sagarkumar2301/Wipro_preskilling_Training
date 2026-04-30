CREATE FUNCTION dbo.CalculateBonus
(
    @Salary DECIMAL(10,2),
    @Department VARCHAR(50)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Bonus DECIMAL(10,2)

    SET @Bonus =
        CASE
            WHEN @Department = 'IT' THEN @Salary * 0.15
            WHEN @Department = 'HR' THEN @Salary * 0.12
            ELSE @Salary * 0.10
        END

    RETURN @Bonus
END