import React, { useState } from "react";

// function Test() {
//   return (
//     <div>
//       <h1>Teste</h1>
//     </div>
//   );
// }

function Teste2() {
  const [count, setCount] = useState(0);

  return (
    <div>
      <p>Você clicou {count} vezes</p>
      <button onClick={() => setCount(count + 1)}>Clique aqui</button>
    </div>
  );
}

export default Teste2;