Public Function GetCultureSelect() As String
 Dim oHashtable As New Hashtable
 For Each oCultureInfo As System.Globalization.CultureInfo _
	In System.Globalization.CultureInfo.GetCultures_
	(System.Globalization.CultureTypes.AllCultures)
  Dim sKey As String = oCultureInfo.Name
  Dim sName As String = oCultureInfo.EnglishName
  Try
   Dim oNumberFormat As System.Globalization.NumberFormatInfo = oCultureInfo.NumberFormat
   Dim s As String = oNumberFormat.CurrencyDecimalSeparator
   Dim sFormat As String = "1" & oNumberFormat.CurrencyGroupSeparator & "234" & _
	oNumberFormat.CurrencyDecimalSeparator & "56"
   If oHashtable.ContainsKey(sFormat) = False Then
    oHashtable.Add(sFormat, sKey & " - " & sName)
   Else
    oHashtable(sFormat) += "<br>" & sKey & " - " & sName
   End If
  Catch ex As Exception
  End Try
 Next
 Dim sb As New System.Text.StringBuilder()
 sb.Append("<table border=1>" & vbCrLf)
 sb.Append("<tr><th>Format</th><th>Country</th></tr>" & vbCrLf)
 For Each oEntry As DictionaryEntry In oHashtable
  sb.Append("<tr><td valign=top>" & oEntry.Key & "</td><td>" & _
	oEntry.Value & "</td></tr>" & vbCrLf)
 Next
 sb.Append("</table>")
 Return sb.ToString()
End Function 

