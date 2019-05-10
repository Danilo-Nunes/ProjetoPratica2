import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import bd.daos.Pessoas;

import javax.swing.JTabbedPane;
import javax.swing.JTextField;
import javax.swing.JLabel;
import javax.swing.JButton;
import javax.swing.JTextPane;
import javax.swing.JTextArea;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class CRUDcomGUI2 extends JFrame {

	private JPanel contentPane;
	private JTextField tfNomeI;
	private JTextField tfCepI;
	private JTextField tfComplementoI;
	private JTextField tfNumeroI;
	private JTextField tfCodigoE;
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;
	private JTextField textField_3;
	private JTextField tfCodigoA;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					CRUDcomGUI2 frame = new CRUDcomGUI2();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public CRUDcomGUI2() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		tabbedPane.setBounds(10, 11, 414, 240);
		contentPane.add(tabbedPane);
		
		JPanel panel = new JPanel();
		tabbedPane.addTab("Inserir", null, panel, null);
		panel.setLayout(null);
		
		JLabel lblNewLabel = new JLabel("Nome");
		lblNewLabel.setBounds(10, 18, 46, 14);
		panel.add(lblNewLabel);
		
		JLabel lblNewLabel_1 = new JLabel("cep");
		lblNewLabel_1.setBounds(10, 55, 46, 14);
		panel.add(lblNewLabel_1);
		
		JLabel lblNewLabel_2 = new JLabel("Complemento");
		lblNewLabel_2.setBounds(10, 97, 65, 14);
		panel.add(lblNewLabel_2);
		
		tfNomeI = new JTextField();
		tfNomeI.setBounds(90, 15, 309, 20);
		panel.add(tfNomeI);
		tfNomeI.setColumns(10);
		
		tfCepI = new JTextField();
		tfCepI.setBounds(90, 52, 86, 20);
		panel.add(tfCepI);
		tfCepI.setColumns(10);
		
		tfComplementoI = new JTextField();
		tfComplementoI.setBounds(90, 94, 232, 20);
		panel.add(tfComplementoI);
		tfComplementoI.setColumns(10);
		
		JLabel lblNumero = new JLabel("numero");
		lblNumero.setBounds(10, 135, 46, 14);
		panel.add(lblNumero);
		
		tfNumeroI = new JTextField();
		tfNumeroI.setBounds(90, 132, 51, 20);
		panel.add(tfNumeroI);
		tfNumeroI.setColumns(10);
		
		JButton btnInserir = new JButton("Inserir");
		btnInserir.setBounds(299, 163, 89, 23);
		panel.add(btnInserir);
		
		JPanel panel_1 = new JPanel();
		tabbedPane.addTab("Excluir", null, panel_1, null);
		panel_1.setLayout(null);
		
		JLabel lblNewLabel_3 = new JLabel("Codigo:");
		lblNewLabel_3.setBounds(21, 22, 46, 14);
		panel_1.add(lblNewLabel_3);
		
		tfCodigoE = new JTextField();
		tfCodigoE.setBounds(64, 19, 86, 20);
		panel_1.add(tfCodigoE);
		tfCodigoE.setColumns(10);
		
		JButton btnExcluir = new JButton("Excluir");
		btnExcluir.setBounds(289, 158, 89, 23);
		panel_1.add(btnExcluir);
		
		JPanel panel_2 = new JPanel();
		tabbedPane.addTab("Alterar", null, panel_2, null);
		panel_2.setLayout(null);
		
		JLabel label = new JLabel("Nome");
		label.setBounds(10, 45, 46, 14);
		panel_2.add(label);
		
		textField = new JTextField();
		textField.setColumns(10);
		textField.setBounds(90, 42, 309, 20);
		panel_2.add(textField);
		
		JLabel label_1 = new JLabel("cep");
		label_1.setBounds(10, 82, 46, 14);
		panel_2.add(label_1);
		
		textField_1 = new JTextField();
		textField_1.setColumns(10);
		textField_1.setBounds(90, 79, 86, 20);
		panel_2.add(textField_1);
		
		JLabel label_2 = new JLabel("Complemento");
		label_2.setBounds(10, 124, 65, 14);
		panel_2.add(label_2);
		
		textField_2 = new JTextField();
		textField_2.setColumns(10);
		textField_2.setBounds(90, 121, 232, 20);
		panel_2.add(textField_2);
		
		JLabel label_3 = new JLabel("numero");
		label_3.setBounds(10, 162, 46, 14);
		panel_2.add(label_3);
		
		textField_3 = new JTextField();
		textField_3.setColumns(10);
		textField_3.setBounds(90, 159, 51, 20);
		panel_2.add(textField_3);
		
		JButton btnAlterar = new JButton("Alterar");
		btnAlterar.setBounds(310, 167, 89, 23);
		panel_2.add(btnAlterar);
		
		JLabel lblNewLabel_4 = new JLabel("codigo");
		lblNewLabel_4.setBounds(10, 11, 46, 14);
		panel_2.add(lblNewLabel_4);
		
		tfCodigoA = new JTextField();
		tfCodigoA.setBounds(90, 8, 86, 20);
		panel_2.add(tfCodigoA);
		tfCodigoA.setColumns(10);
		
		JPanel panel_3 = new JPanel();
		tabbedPane.addTab("Selecionar", null, panel_3, null);
		panel_3.setLayout(null);		
		
		JTextArea textArea = new JTextArea();
		textArea.setBounds(10, 45, 389, 156);
		panel_3.add(textArea);
		
		JButton btnMostrar = new JButton("Mostrar");
		btnMostrar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				textArea.add(Pessoas.getPessoas());
			}
		});		

		btnMostrar.setBounds(10, 11, 89, 23);
		panel_3.add(btnMostrar);
	}
}
