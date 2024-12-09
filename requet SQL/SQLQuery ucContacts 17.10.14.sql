SELECT * FROM MDB_SYS_SCREEN_USER WHERE  SCREEN_CD = 'CF-CTL-CNT-001' AND  SCREEN_USER = 'iond'


select * from CiCmpy where cmp_code = 'usa434'

SELECT		C.ID, c.PredCode, c.FullName, ISNULL(C.TaalCode, '') AS TaalCode, 
 T.OMS30_0 AS OMS30_0, RTRIM(ISNULL(C.cnt_f_tel, '')) + ' ' + RTRIM(ISNULL(C.cnt_f_ext, '')) AS cnt_f_tel, 
 RTRIM(C.cnt_email) AS cnt_email, RTRIM(C.cnt_f_fax) AS cnt_f_fax, ISNULL(H.Fullname, '') AS Alternate_CSR 
 FROM		cicntp C WITH (Nolock) 
 LEFT JOIN	taal T WITH (Nolock) ON C.taalcode = T.taalcode 
 LEFT JOIN  humres H WITH (Nolock) ON C.NumberField1 = H.Res_ID 
 WHERE		C.cmp_wwn = '7AF3431B-0A10-45B5-AD5C-03E6CA7F5115'  and C.FullName  = 'BRIANA CLARK'
 ORDER BY	C.FullName 

select * from cicntp where cmp_wwn = '7AF3431B-0A10-45B5-AD5C-03E6CA7F5115' and fullName = 'BRIANA CLARK'
select  * from Addresses 
where Account = '7AF3431B-0A10-45B5-AD5C-03E6CA7F5115' and ContactPerson = '95F1D72A-4FB1-48F9-A1F4-01189A7CECE1'
select  * from ShippingDays where AddressId = '4CD9F4E2-AA51-481E-85F2-B5B643A7871C'
select  * from BacoDiscussionStdPictures 
where Description = '_usa434' And Filename = 'BRIANA CLARK'
select  * from EXACT_TRAVELER_NEW_CONTACTS_FROM_APP where 
cmp_wwn = '7AF3431B-0A10-45B5-AD5C-03E6CA7F5115' and cnt_id = '95F1D72A-4FB1-48F9-A1F4-01189A7CECE1'

