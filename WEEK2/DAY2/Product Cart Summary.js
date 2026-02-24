// Product Cart Summary 

// Store product objects in an array
const products = [
  { name: "Laptop", price: 50000, quantity: 1 },
  { name: "Mouse", price: 500, quantity: 2 },
  { name: "Keyboard", price: 1500, quantity: 1 }
];

// Arrow function to calculate total cart value using reduce()
const calculateTotal = (items) =>
  items.reduce(
    (total, product) => total + product.price * product.quantity,
    0
  );

// Create invoice lines using map()
const invoiceLines = products.map(
  (product) =>
    `${product.name} - ₹${product.price} x ${product.quantity} = ₹${
      product.price * product.quantity
    }`
);

// Calculate total amount
const totalAmount = calculateTotal(products);

// Display formatted invoice using template literals
console.log(`
🛒 Shopping Cart Invoice
-------------------------
${invoiceLines.join("\n")}

Total Amount: ₹${totalAmount}
`);