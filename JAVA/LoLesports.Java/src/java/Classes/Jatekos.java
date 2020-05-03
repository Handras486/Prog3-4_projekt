/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Classes;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author Andras
 */
@WebServlet(name = "Jatekos", urlPatterns = {"/Jatekos"})
public class Jatekos extends HttpServlet {
    static Random R=new Random();
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    
    static String[] poziciok  = new String[]{"TOP","JNG","MID","BOT","SUP"};
    static String[] nemzetisegek = new String[]{"Denmark","United States","South Korea","United Kingdoms","China"};
    static String[] csapatrov  = new String[]{"G2","IG","SKT","C9"};
    

    
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/xml;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            String nev=request.getParameter("nev");
            out.println("<jatekos>");
            out.println("<nev>"+nev+"</nev>");
            out.println("<eletkor>" + (R.nextInt(99)) + "</eletkor>");
            out.println();
            out.println("<pozicio>" + poziciok[R.nextInt(poziciok.length)] + "</pozicio>");
            out.println();
            out.println("<nemzetiseg>" + nemzetisegek[R.nextInt(nemzetisegek.length)] + "</nemzetiseg>");
            out.println();
            out.println("<csapatrov>" + csapatrov[R.nextInt(csapatrov.length)] + "</csapatrov>");
            out.println("</jatekos>");
        }
        
    }
    
        // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>
}
