<h1 align="center" id="inicio">ADS-Registro-de-Estudantes</h1>

## Seções do README
<ul>
  <li><a href="#projeto">💻 Projeto</a></li>
  <li><a href="#tecnologias">🚀 Tecnologias</a></li>
  <li><a href="#layout">🔖 Layout</a></li>
  <li><a href="#codigo"> 📑 Código</a></li>
  <li><a href="#devs">👩‍💻 Devs</a></li>
</ul>

## <a id="projeto">💻 Projeto</a>

<p align="justify">
  Olá, esse projeto foi feito para a matéria de Hands on Work IV do curso Análise e Desenvolvimento de Sistemas<br>
  O objetivo desse porjeto é criar um CRUD utilizando C# e a IDE Visual Studio Comunity.<br>
  Aqui você pode ver o vídeo preparado para apresentar o projeto no <a href="https://youtu.be/3nXLiyt3rL0">YouTube</a>
</p>

## <a id="tecnologias">🚀 Tecnologias</a>

Esse projeto foi desenvolvido com as seguintes tecnologias:

- C#
- Visual Studio Community


## <a id="layout">🔖 Layout</a>

Vamos agora ver algumas imagens e GIF do sistema em funcionamento.<br>

Layout:
<div align="center">
<table>
  <tr>
    <td align="center">
          <p>Tela Inicial</p>
      <img width="80%" src="https://github.com/1matheusflorencio/ADS-Registro-de-Estudantes/blob/master/README%20arquivos/Tela%20de%20Bem%20Vindos.png?raw=true" alt="Tela de Bem Vindos" /><br>
        <sub>
         Tela de Bem Vindos
        </sub>
    </td>
  </tr>
  <tr>
    <td align="center">
      <br>
          <p>CRUD</p>
      <img width="80%" src="https://github.com/1matheusflorencio/ADS-Registro-de-Estudantes/blob/master/README%20arquivos/Telas%20do%20CRUD.png?raw=true" alt="Tela do CRUD" /><br>
        <sub>
         Tela do CRUD
        </sub>
    </td>
  </tr>
    <tr>
    <td align="center">
      <br>
          <p>Alunos</p>
      <img width="80%" src="https://github.com/1matheusflorencio/ADS-Registro-de-Estudantes/blob/master/README%20arquivos/Tela%20de%20Alunos.png?raw=true" alt="Tela dos Alunos" /><br>
        <sub>
         Tela dos Alunos
        </sub>
    </td>
  </tr>
</table>
<p width="100%" align="end"><a href="#inicio">🔝 Ir para o Início</a></p>
</div>

---

## <a id="codigo">📑 Código</a>

<p>Vamos agora dar uma olhada nos códigos utilizados</p>

<!--
//Atualiza a Tabela de Registro com os Estudantes registrados
```
    private void table_update() {
        int CC;
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conexao = DriverManager.getConnection("jdbc:mysql://localhost/registrodealunos","root","");
            inserir = conexao.prepareStatement("SELECT * FROM registro");
            ResultSet Rs = inserir.executeQuery();
            
            ResultSetMetaData RSMD = Rs.getMetaData();
            CC = RSMD.getColumnCount();
            DefaultTableModel DFT = (DefaultTableModel) jTable3.getModel();
            DFT.setRowCount(0);

            while (Rs.next()) {
                Vector v2 = new Vector();
           
                for (int ii = 1; ii <= CC; ii++) {
                    v2.add(Rs.getString("id"));
                    v2.add(Rs.getString("nome"));
                    v2.add(Rs.getString("idestudante"));
                    v2.add(Rs.getString("curso"));
                }
                DFT.addRow(v2);
            }
        } catch (Exception e) {
        }
    }
```

// Botão Adicionar, responsável por fazer o INSERT no Banco de Dados
```
    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {                                         
        
  String nome =txtnome.getText();
  String idestudante =txtid.getText();
  String curso =txtcurso.getText();
 
        try {
            Class.forName("com.mysql.jdbc.Driver");
            conexao = DriverManager.getConnection("jdbc:mysql://localhost/registrodealunos","root","");
            inserir = conexao.prepareStatement("insert into registro(nome,idestudante,curso)values(?,?,?)");
            inserir.setString(1, nome);
            inserir.setString(2, idestudante);
            inserir.setString(3, curso);
            inserir.executeUpdate();
            
            JOptionPane.showMessageDialog(this,"Registro Salvo");
            
            txtnome.setText("");
            txtid.setText("");
            txtcurso.setText("");
            txtnome.requestFocus();  
            table_update();
            
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(reg.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(reg.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
```

// Botão Deletar, responsável por fazer o DELET no Banco de Dados

```
    private void jButton2ActionPerformed(java.awt.event.ActionEvent evt) {                                         
          // Funcão de Deletar
          DefaultTableModel model = (DefaultTableModel) jTable3.getModel();
          int selectedIndex = jTable3.getSelectedRow();
            try {   
                
            int id = Integer.parseInt(model.getValueAt(selectedIndex, 0).toString());
            int dialogResult = JOptionPane.showConfirmDialog (null, "Você quer Deletar o Registro?","Aviso!",JOptionPane.YES_NO_OPTION);
            if(dialogResult == JOptionPane.YES_OPTION){

            Class.forName("com.mysql.jdbc.Driver");
            conexao = DriverManager.getConnection("jdbc:mysql://localhost/registrodealunos","root","");
            inserir = conexao.prepareStatement("delete from registro where id = ?");
        
            inserir.setInt(1,id);
            inserir.executeUpdate();
            JOptionPane.showMessageDialog(this, "Registro Deletado");
            txtnome.setText("");
            txtid.setText("");
            txtcurso.setText("");
            table_update();
           }
        } catch (ClassNotFoundException ex) {   
        } catch (SQLException ex) {     
        }
    }
```

// Botão Atualizar, responsável por fazer o UPDATE no Banco de Dados
```
    private void jButton3ActionPerformed(java.awt.event.ActionEvent evt) {                                         

            DefaultTableModel model = (DefaultTableModel) jTable3.getModel();
            int selectedIndex = jTable3.getSelectedRow();
            try {   
                
            int id = Integer.parseInt(model.getValueAt(selectedIndex, 0).toString());
            String nome =txtnome.getText();
            String idestudante =txtid.getText();
            String curso =txtcurso.getText();
  
            Class.forName("com.mysql.jdbc.Driver");
            conexao = DriverManager.getConnection("jdbc:mysql://localhost/registrodealunos","root","");
            inserir = conexao.prepareStatement("update registro set nome= ?,idestudante= ?,curso= ? where id= ?");
            inserir.setString(2,idestudante);
            inserir.setString(3,curso);
            inserir.setInt(4,id);
            inserir.executeUpdate();
            JOptionPane.showMessageDialog(this, "Registro Atualizado");
            txtnome.setText("");
            txtid.setText("");
            txtcurso.setText("");
            table_update();  
        } catch (ClassNotFoundException ex) {
        } catch (SQLException ex) {
        }
    }
```

-->
<p width="100%" align="end"><a href="#inicio">🔝 Ir para o Início</a></p>

---

## <a id="devs">👩‍💻 Devs</a> 

<table>
  <tr>
    <td align="center">
    <a text-decoration="none" href="https://github.com/1matheusflorencio">
      <img src="https://avatars.githubusercontent.com/u/68713424?s=400&u=62c303b85a95a013cccd6cbd6084952fbc06a4db&v=4" width="150px;" alt="Foto do Matheus Florêncio no GitHub"/>       <br>
        <sub>
          <b>Matheus Florêncio</b> <br>
        </sub>
    </a>
    </td>
      <td align="center" width="150px">
        <p>Info sobre o Dev</p>
          <a href="https://www.matheusflorencio.com" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/website-000000?style=for-the-badge&logo=About.me&logoColor=white"></a>
          <br>
          <a href="https://www.linkedin.com/in/matheus-flor%C3%AAncio/" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white"></a>
          <br>
          <a href="https://www.instagram.com/1matheusflorencio/" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white" target="_blank"></a>
          <br>
          <a href="https://www.youtube.com/channel/UCH1VWs-9V63VyGkrcSbtXIg" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" target="_blank"></a>
      </td>       
       <!-- Outro Dev -->
        <td align="center">
    <a text-decoration="none" href="#">
      <img src="https://avatars.githubusercontent.com/u/80532267?v=4" width="150px;" alt="Foto do Lucas de Lunaio no GitHub"/>
      <br>
        <sub>
          <b>Lucas de Luna</b> <br>
        </sub>
    </a>
    </td>
      <td align="center" width="150px">
      <!-- Informações Sobre o Dev e Links para suas redes -->
        <p>Info sobre o Dev</p>
          <br>
          <br>
          <br>
          <br>
          <a href="https://github.com/LucasLTCouto" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white"></a>
          <a href="https://www.instagram.com/lucasdeluna11/" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white" target="_blank"></a>
      </td>
            <td align="center">
    <a text-decoration="none" href="#">
      <img src="https://avatars.githubusercontent.com/u/84678879?v=4" width="150px;" alt="Foto do Lucas de Lunaio no GitHub"/>
      <br>
        <sub>
          <b>Evandro Orlandini</b> <br>
        </sub>
    </a>
    </td>
    <!-- Informações Sobre o Dev e Links para suas redes -->
      <td align="center" width="150px">
        <p>Info sobre o Dev</p>
          <br>
          <br>
          <br>
          <br>
          <a href="https://github.com/EvandroOrlandini" target="_blank"><img height="30px" width="120px" src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white"></a>
      </td>
    </tr>
</table>

<p width="100%" align="end"><a href="#inicio">🔝 Ir para o Início</a></p>
