<%@ Page Title="" Language="C#" MasterPageFile="MasterStrana.Master" AutoEventWireup="true" CodeBehind="Igraj.aspx.cs" Inherits="LotoRotoProjekat.Igraj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">           
    <div class="card-body" style="margin: 0;position: absolute;top: 50%;left: 50%;-ms-transform: translate(-50%, -50%);transform: translate(-50%, -50%);";>
              <a href="Cigla.aspx" target="_blank" class="btn btn-indigo"style="width:290px;">DOK ČEKATE NA IZVLAČENJE!</a>
            </div>
 <asp:Label ID="prikazKombinacijeTiketa" runat="server" Text="" style="border-collapse:collapse;width: 280px;height:50px;font-size:24px;margin-left:15px;background-color:#FFFFFF;color:blue;" ></asp:Label>
  <div class="btn-indigo" style="width:170px;margin-left:30px;margin-top:20px;">  
      <asp:Button class="btn btn-indigo" ID="buttonClick" Text="click function" runat="server" OnClick="buttonClick_Click" Width="160px"/>
      
       
 
      <asp:GridView ID="GridView1" style="width: 140px;height:502px;margin-left:16px;background-color:#ffffff;text-align:center;font-size:14px;color:#b200ff;" runat="server" Visible="False"
      OnRowCommand="GridView1_RowCommand"  ForeColor="#0a10b5" BackColor="#66ffff"  AutoGenerateColumns="False">
      
      <Columns>
        
        <asp:ButtonField HeaderText = "" DataTextField="Prvi" CommandName="Prvi"/>
        <asp:ButtonField HeaderText = "" DataTextField="Drugi" CommandName="Drugi"/>
        <asp:ButtonField HeaderText = "" DataTextField="Treci" CommandName="Treci"/> 

      </Columns>
            
        </asp:GridView>

    <asp:Button class="btn btn-indigo" ID="Button1" runat="server" OnClick="Button1_Click" Text="Potvrdi" Width="160px" />

  </div>
    
                <!--Card content-->
  
</asp:Content>
