import { ReactNode } from "react";

type ButtonProps = {
	children: ReactNode;
	onClick: () => void;
};

const Button = (props: ButtonProps) => {
	const { children, onClick } = props;

	return (
		<button className={""} onClick={onClick}>
			{children}
		</button>
	);
};

export default Button;
