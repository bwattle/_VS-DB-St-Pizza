﻿Public Class Pizza102
    'set up a record or "class" for a student
    Class STUDENT
        Public studID As Int16
        Public firstName As String
        Public lastName As String
        Public deliveryDate As Date
        Public postcode As String  'even though postcode is a number, we store it as a string
        Public quantity As Byte    'Max quantity is 255 Pizzas
        Public phoneNo As String   'Phone numbers are NEVER used to calculate, so saved as text
        Public street As String
        Public suburb As String
        Public hour As Byte        '# between 0 and 23 - it can never be > 255
        Public minute As Byte      '# between 0 and 59 - it can never be > 255
        Public pizzaBase As String 'short name for base
        Public top1 As Boolean
        Public top2 As Boolean
        Public top3 As Boolean
        Public top4 As Boolean
    End Class

    Dim students(9) As STUDENT
    Dim studentCount As Integer = 0
    Dim basePrice As Single
    Dim top1price As Single
    Dim top2price As Single
    Dim top3price As Single
    Dim top4price As Single
    Dim toppedPrice As Single

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'allocate memory
        For i = 0 To 9
            students(i) = New STUDENT
        Next
        'load default prices
        basePrice = 10
        top1price = 0.3
        top2price = 0.45
        top3price = 0.9
        top4price = 1.3

        'display prices
        txtBasePrice.Text = FormatCurrency(basePrice)
        txtTop1.Text = FormatCurrency(top1price)
        txtTop2.Text = FormatCurrency(top2price)
        txtTop3.Text = FormatCurrency(top3price)
        txtTop4.Text = FormatCurrency(top4price)


        'load 4 test records
        students(0).studID = 1
        students(0).firstName = "Johnny"
        students(0).lastName = "Depp"
        students(0).deliveryDate = "9/6/63"
        students(0).postcode = "m"
        students(0).quantity = 78.2
        students(1).studID = 2
        students(1).firstName = "Jennifer"
        students(1).lastName = "Lawrence"
        students(1).deliveryDate = "15/8/90"
        students(1).postcode = "f"
        students(1).quantity = 88.2
        students(2).studID = 3
        students(2).firstName = "George"
        students(2).lastName = "Clooney"
        students(2).deliveryDate = "6/5/61"
        students(2).postcode = "m"
        students(2).quantity = 68.2
        students(3).studID = 4
        students(3).firstName = "Scarlett"
        students(3).lastName = "Johansson"
        students(3).deliveryDate = "22/11/84"
        students(3).postcode = "f"
        students(3).quantity = 72.2
        'set the student count to the number of students which have been entered
        studentCount = 4
        displayList()
        CalcToppedPrice()
        CalcTotalPrice()
    End Sub
    Private Sub btnAddStud_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        students(studentCount).studID = studentCount + 1 'allocate the new student ID to an incremented value
        'place text from text boxes into the array - first students(0), then students(1), students(2) etc
        students(studentCount).firstName = txtFirstName.Text
        students(studentCount).lastName = txtLastName.Text
        students(studentCount).deliveryDate = dteDelivery.Text & " " & cboHour.Text & ":" & cboMinute.Text
        students(studentCount).postcode = txtPostcode.Text
        students(studentCount).quantity = txtQuantity.Text
        studentCount += 1
        'return text boxes to blank ready for next entry
        txtFirstName.Text = ""
        txtLastName.Text = ""
        dteDelivery.Text = ""
        txtPostcode.Text = ""
        txtQuantity.Text = 1
        displayList()
    End Sub
    Private Sub displayList()
        'clear the list box as it keeps the earlier loop
        txtStList.Items.Clear()
        'loop through the array to print all rows
        For i = 0 To studentCount - 1
            txtStList.Items.Add(students(i).studID & " - " & students(i).firstName & " - " &
                              UCase(students(i).lastName) & " - " & students(i).deliveryDate & " - " &
                              students(i).postcode & " - " & students(i).quantity)
        Next
    End Sub

    Private Sub CalcToppedPrice()
        toppedPrice = basePrice
        If chkTop1.Checked Then 'later theese 4 IF statements could be replaced with a loop
            toppedPrice += top1price
        End If
        If chkTop2.Checked Then
            toppedPrice += top2price
        End If
        If chkTop3.Checked Then
            toppedPrice += top3price
        End If
        If chkTop4.Checked Then
            toppedPrice += top4price
        End If
        txtToppedPrice.Text = FormatCurrency(toppedPrice)
    End Sub

    Private Sub chkTop1_CheckedChanged(sender As Object, e As EventArgs) Handles chkTop1.CheckedChanged
        CalcToppedPrice()
        CalcTotalPrice()
    End Sub

    Private Sub chkTop2_CheckedChanged(sender As Object, e As EventArgs) Handles chkTop2.CheckedChanged
        CalcToppedPrice()
        CalcTotalPrice()
    End Sub

    Private Sub chkTop3_CheckedChanged(sender As Object, e As EventArgs) Handles chkTop3.CheckedChanged
        CalcToppedPrice()
        CalcTotalPrice()
    End Sub

    Private Sub chkTop4_CheckedChanged(sender As Object, e As EventArgs) Handles chkTop4.CheckedChanged
        CalcToppedPrice()
        CalcTotalPrice()
    End Sub
    Private Sub CalcTotalPrice()
        txtTotalPrice.Text = FormatCurrency(toppedPrice * CInt(txtQuantity.Text))
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        CalcTotalPrice()
    End Sub
End Class
