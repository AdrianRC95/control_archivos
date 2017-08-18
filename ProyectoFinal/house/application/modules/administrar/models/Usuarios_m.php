<?php
class Usuarios_m extends CI_Model {

    public function __construct()
    {
        $this->load->database();
        $this->load->model('des_encripta_m');
    }
    
    public function get_usuarios($id = null)
    {
        if ($id === null)
        {
            $query = $this->db->get('usuario');
            return $query->result_array();
        }
        $query = $this->db->get_where('usuario', array('id_usuario' => $id));
        return $query->result_array();
    }
    
    public function agregarUsuario()
    {
        $this->load->helper('url');

        $data = array(
            'nombre' => $this->input->post('nombre'),
            'email' => $this->input->post('email'),
            'password' => $this->des_encripta_m->encriptar($this->input->post('pass')),
            'rol' => $this->input->post('rol')
        );

        return $this->db->insert('usuario', $data);
    }
    
    public function actualizarUsuario()
    {
        $this->load->helper('url');
        
        $id = $this->input->post('id');
        $data = array(
            'nombre' => $this->input->post('nombre'),
            'email' => $this->input->post('email'),
            'password' => $this->des_encripta_m->encriptar($this->input->post('pass')),
            'rol' => $this->input->post('rol')
        );
        $this->db->where('id_usuario', $id);
        return $this->db->update('usuario', $data);
    }
    
    public function eliminarUsuario($id = null)
    {
        $this->db->where('id_usuario', $id);
        return $this->db->delete('usuario');
    }
}