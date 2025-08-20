-- masterminutes
---------------------
--------------------
create or alter proc dbo.Meeting_Minutes_Master_Save_SP
    @CustomerType nvarchar(50),
    @CustomerId int,
    @MeetingDate date,
    @MeetingTime time(0),
    @MeetingPlace nvarchar(200),
    @AttendsFromClientSide nvarchar(500),
    @AttendsFromHostSide nvarchar(500),
    @MeetingAgenda nvarchar(500),
    @MeetingDiscussion nvarchar(2000),
    @MeetingDecision nvarchar(1000),
    @NewId int output
    as
    begin
        set nocount on;
        insert into dbo.Meeting_Minutes_Master_Tbl
            (
                CustomerType,CustomerId,MeetingDate,MeetingTime,MeetingPlace, AttendsFromClientSide,
                AttendsFromHostSide, MeetingAgenda,MeetingDiscussion, MeetingDecision
            )
        values
            (
                @CustomerType,@CustomerId, @MeetingDate,@MeetingTime,@MeetingPlace,@AttendsFromClientSide,
                @AttendsFromHostSide, @MeetingAgenda,@MeetingDiscussion,@MeetingDecision
            );
        set @NewId = cast(SCOPE_IDENTITY() as int);
    end
    go
---------------------------
--------------------------
--details
create or alter proc dbo.Meeting_Minutes_Details_Save_SP
    @MeetingMinuteId   int,
    @ProductServiceId  int,
    @Quantity decimal(18,2),
    @Unit nvarchar(50)
    as
    begin
        set nocount on;

        insert into dbo.Meeting_Minutes_Details_Tbl (MeetingMinuteId,ProductServiceId, Quantity, Unit )
        values (@MeetingMinuteId, @ProductServiceId,@Quantity, @Unit);
    end
 GO
 --------------
 -------------------